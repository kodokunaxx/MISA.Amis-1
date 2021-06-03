<template>
  <ul class="MISANode" :deepLevel="deepLevel">
    <!------------------------------------------------------------->
    <li class="Row">
      <div
        class="Column"
        v-for="(value, key) in node.parent"
        :key="key"
        :class="key"
        :style="parentStyle"
        v-show="columns.includes(key)"
        @click="selectRow($event.target.parentElement)"
      >
        {{ value }}
      </div>
      <div class="Column Feature">
        <div class="Wrapper">
          <div class="Text">Sửa</div>
          <div class="Icon" @click="openContextMenu($event)"></div>
        </div>
      </div>
    </li>

    <!------------------------------------------------------------->
    <li v-if="isShowDetail && node.children && node.children.length">
      <node
        v-for="(child, i) in node.children"
        :key="i"
        :node="child"
        :columns="columns"
        :deepLevel="parseInt(deepLevel) + 1"
        @reload="reload()"
        @showCannotDelete="showCannotDelete()"
        @showConfirmDelete="showConfirmDelete($event)"
      ></node>
    </li>
    <!------------------------------------------------------------->
    <div
      class="icon"
      v-if="node.children && node.children.length"
      @click="toggle()"
    ></div>
    <!------------------------------------------------------------->
    <ContextMenu ref="menu" v-show="isShowContextMenu" :w="170">
      <ul>
        <li @click="closeContextMenu()">Nhân bản</li>
        <li @click="closeContextMenu(), checkDelete(node.parent)">
          Xóa
        </li>
        <li @click="closeContextMenu()">Chuyển tài khoản hạch toán</li>
        <li @click="closeContextMenu()">Ngừng sử dụng</li>
      </ul>
    </ContextMenu>
    <Popup v-if="cannotDeleteRoot">
      <template v-slot:Head>
        <div class="icon-popup icon-warning"></div>
        <div class="text">
          <span style="font-weight: 600; display: block; margin-bottom: 20px">
            Xóa không thành công.
          </span>
          <span
            >Không thể xóa danh mục cha nếu chưa xóa tất cả các danh mục
            con.</span
          >
        </div>
      </template>
      <template v-slot:Button>
        <div class="btn-close">
          <button @click="closeCannotDelete()">Đóng</button>
        </div>
      </template>
    </Popup>
    <Popup v-if="confirmDelete">
      <template v-slot:Head>
        <div class="icon-popup icon-dangerous"></div>
        <div class="text">
          Bạn có thực sự muốn xóa Tài khoản {{ accountNumber }} không?
        </div>
      </template>
      <template v-slot:Button>
        <div class="wrapper">
          <div class="btn-cancel">
            <button class="btn" @click="closeConfirmDelete()">Không</button>
          </div>
          <div class="btn-confirm">
            <button
              class="btn"
              @click="closeConfirmDelete(), deleteAccount(id)"
            >
              Có
            </button>
          </div>
        </div>
      </template>
    </Popup>
  </ul>
</template>

<script>
import ContextMenu from "../base/ContextMenu";
import Popup from "../base/Popup";
import axios from "axios";

export default {
  name: "node",
  props: ["node", "deepLevel", "columns"],
  computed: {
    parentStyle() {
      return {
        fontWeight: this.node.children && this.node.children.length ? 600 : 500,
      };
    },
  },
  components: {
    ContextMenu,
    Popup,
  },
  data() {
    return {
      API_URL: this.$store.getters.getApiUrl,
      isShowDetail: false,
      isShowContextMenu: false,
      cannotDeleteRoot: false,
      confirmDelete: false,
      id: null,
      accountNumber: null,
    };
  },
  methods: {
    /**
     * Đóng, hoặc mở node con
     * CreatedBy: nvcuong (02/06/2021)
     */
    toggle() {
      this.isShowDetail = !this.isShowDetail;
      this.refactorTable();
    },

    /**
     * Lấy dữ liệu tài khoản theo dạng Tree
     * CreatedBy: nvcuong (02/06/2021)
     */
    getTreeAccount(accounts) {
      this.$store.commit("setAccounts", this.recursive(accounts, 0));
    },
    recursive(accounts, index) {
      const result = [];
      const obj = {};
      while (index < accounts.length) {
        if (accounts[index].rgt - accounts[index].lft == 1) {
          obj.parent = accounts[index];
          obj.children = [];
          index++;
        } else {
          obj.parent = accounts[index];
          const limit = accounts[index++].rgt;
          const arr = [];

          while (index < accounts.length && accounts[index].rgt < limit) {
            arr.push(accounts[index]);
            index++;
          }
          obj.children = this.recursive(arr, 0);
        }
        result.push({
          parent: obj.parent,
          children: obj.children,
        });
        obj.parent = null;
        obj.children = [];
      }
      return result;
    },
    /**
     * Reload
     * CreatedBy: nvcuong (03/06/2021)
     */
    async reload() {
      // Lấy dữ liệu
      this.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
      await this.$store.dispatch("setAccounts");
      this.getTreeAccount(this.$store.getters.getAccounts);
      this.$store.commit("setIsLoading", false); // Tắt hiệu ứng loading
    },

    /**
     * Kiểm tra xóa node cần xóa có node con không
     *  CreatedBy: nvcuong (02/06/2021)
     */
    checkDelete(account) {
      const id = account.AccountId;
      const accountNumber = account.AccountNumber;
      const lft = account.lft;
      const rgt = account.rgt;
      if (rgt - lft > 1) {
        this.$emit("showCannotDelete");
      } else {
        this.$emit("showConfirmDelete", { id, accountNumber });
      }
    },
    /**
     * Refactor lại table sau khi đóng, hoặc mở node con
     * CreatedBy: nvcuong (02/06/2021)
     */
    refactorTable() {
      setTimeout(function() {
        const nodes = document.querySelectorAll(".MISANode");
        let deepLevel = 1;
        nodes.forEach((node) => {
          const tmpDeepLevel = node.attributes.deepLevel;
          if (tmpDeepLevel && tmpDeepLevel.value > deepLevel) {
            deepLevel = tmpDeepLevel.value;
          }
        });

        const accNumColumns = document.querySelectorAll(
          ".MISANode .AccountNumber"
        );

        accNumColumns.forEach((accNumColumn) => {
          const deep =
            accNumColumn.parentElement.parentElement.attributes.deepLevel;
          if (deep) {
            accNumColumn.style.width =
              (deepLevel - deep.value) * 20 + 150 + "px";
          } else {
            accNumColumn.style.width = (deepLevel - 1) * 20 + 150 + "px";
          }
        });
      }, 0);
    },
    /**
     * Chọn row
     * CreatedBy: nvcuong (02/06/2021)
     */
    selectRow(target) {
      const path = ".MISAAccount-System .Root .MISANode .Row.selected";
      const selectedRows = document.querySelectorAll(path);

      selectedRows.forEach((selectedRow) =>
        selectedRow.classList.remove("selected")
      );
      target.classList.add("selected");
    },

    /**
     * Hiện context menu
     * @param e Event
     * CreatedBy: nvcuong(26/05/2021)
     */
    openContextMenu(e) {
      this.isShowContextMenu = true;
      this.$refs.menu.open(e);
    },
    closeContextMenu() {
      this.isShowContextMenu = false;
    },
    /**
     * Xóa node
     * CreatedBy: nvcuong (02/06/2021)
     */
    deleteAccount(id) {
      const vm = this;
      const API_URL = this.API_URL + "/accounts/" + id;

      try {
        this.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
        axios
          .delete(API_URL)
          .then(async () => {
            vm.$emit("reload"); // Reload;
            vm.$store.commit("setIsLoading", false); // Tắt hiệu ứng loading
          })
          .catch((error) => {
            console.log(error.response);
          });
      } catch (error) {
        error;
      }
    },
    /**
     * Hiện popup xác nhận xóa
     * CreatedBy: nvcuong (03/06/2021)
     */
    showConfirmDelete(payload) {
      this.confirmDelete = true;
      this.id = payload.id;
      this.accountNumber = payload.accountNumber;
    },

    /**
     * Hiện popup không thể xóa
     * CreatedBy: nvcuong (03/06/2021)
     */
    showCannotDelete() {
      this.cannotDeleteRoot = true;
    },

    /**
     * Ẩn popup xác nhận xóa
     * CreatedBy: nvcuong (03/06/2021)
     */
    closeConfirmDelete() {
      this.confirmDelete = false;
    },

    /**
     * Ẩn popup không thể xóa
     * CreatedBy: nvcuong (03/06/2021)
     */
    closeCannotDelete() {
      this.cannotDeleteRoot = false;
    },
  },
};
</script>

<style lang="scss"></style>
