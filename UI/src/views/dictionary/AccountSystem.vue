<template>
  <div class="MISAAccount-System ">
    <div class="MISAAccount-System-Head flex items-center">
      <div class="MISAAccount-System-Head-ASList">
        <div class="title">Hệ thống tài khoản</div>
        <div class="back-to-all">
          <span class="icon"></span>
          <a href="#">
            Tất cả các danh mục
          </a>
        </div>
      </div>
      <div class="MISAAccount-System-Head-Button">
        <div class="btn btn-change-account">Chuyển tài khoản hoạch toán</div>
        <div class="btn btn-add" @click="openDialog()">Thêm</div>
      </div>
    </div>
    <div class="Content-Feature">
      <div class="Feature-Left">
        <div class="Feature-Filter">
          <input
            type="text"
            class="Search-input"
            placeholder="Tìm kiếm theo số, tên tài khoản"
            ref="search"
          />
          <div class="icon"></div>
        </div>
      </div>
      <div class="Feature-Right">
        <div class="Shorten">Thu gọn</div>
        <div
          class="Icon Feature-Reload"
          title="Lấy lại dữ liệu"
          @click="reload()"
        ></div>
        <div class="Icon Feature-Export-Excel" title="Xuất ra Excel"></div>
      </div>
    </div>
    <div class="MISAAccount-System-Content">
      <div class="MISAAccount-System-Content-Table">
        <div class="Thead">
          <div class="MISANode">
            <div class="Row">
              <div class="Column AccountNumber">SỐ TÀI KHOẢN</div>
              <div class="Column AccountName">TÊN TÀI KHOẢN</div>
              <div class="Column Kind">TÍNH CHẤT</div>
              <div class="Column EnglishName">TÊN TIẾNG ANH</div>
              <div class="Column Explain">DIỄN GIẢI</div>
              <div class="Column Status">TRẠNG THÁI</div>
              <div class="Column Feature">CHỨC NĂNG</div>
            </div>
          </div>
        </div>
        <div class="Tbody">
          <div class="Root">
            <Node
              :node="account"
              :deepLevel="1"
              :columns="columns"
              v-for="account in this.$store.getters.getAccounts"
              :key="account.AccountId"
              @reload="reload()"
              @showCannotDelete="showCannotDelete()"
              @showConfirmDelete="showConfirmDelete($event)"
            />
          </div>
        </div>
        <div class="Data-Pagenav">
          <div class="Data-Pagenav-Left">
            <div class="Total-Row">
              Tổng số:
              <span style="font-weight: 600">{{
                $store.getters.getTotalAccount
              }}</span>
              bản ghi
            </div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading v-if="this.$store.getters.getIsLoading" />
    <AccountDialog @reload="reload()" />
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
  </div>
</template>

<script>
import Node from "../../components/account-system/Node";
import BaseLoading from "../../components/base/BaseLoading";
import AccountDialog from "../../components/dialog/account-system/AccountDialog";
import Popup from "../../components/base/Popup";
import axios from "axios";

export default {
  components: {
    Node,
    BaseLoading,
    AccountDialog,
    Popup,
  },
  async mounted() {
    document.title = "Hệ thống tài khoản";

    // Lấy dữ liệu
    this.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
    await this.$store.dispatch("setAccounts");
    this.getTreeAccount(this.$store.getters.getAccounts);
    this.$store.commit("setIsLoading", false); // Tắt hiệu ứng loading
  },
  data() {
    return {
      API_URL: this.$store.getters.getApiUrl,
      columns: [
        "AccountNumber",
        "AccountName",
        "Kind",
        "EnglishName",
        "Explain",
        "Status",
      ],
      cannotDeleteRoot: false,
      confirmDelete: false,
      id: null,
      accountNumber: null,
    };
  },
  methods: {
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
     * Mở dialog
     * CreatedBy: nvcuong(03/06/2021)
     */
    async openDialog() {
      await this.$store.commit("setIsShowAccountDialog", true); // Mở dialog
      this.focusFirstElement(); // focus first element

      // Bind parent account number
      const parentAccountNumber = this.getParentAccountNumber();
      const path =
        '.MISAAccount-System-Dialog input[field="ParentAccountNumber"]';
      const target = document.querySelector(path);
      target.value = parentAccountNumber;
    },
    /**
     * focus vào ô input đầu tiên
     * CreatedBy: nvcuong (28/05/2021)
     */
    focusFirstElement() {
      setTimeout(function() {
        const path = ".MISAAccount-System-Dialog input[type='text']";
        const focusInput = document.querySelector(path);

        focusInput.focus();
      }, 0);
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

      // refresh lại width của <th> số tài khoản
      const path = ".MISAAccount-System-Content-Table .Thead .AccountNumber";
      const th = document.querySelector(path);
      th.style.width = "150px";
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
            vm.reload(); // Reload;
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
     * Lấy tài khoản cha
     * CreatedBy: nvcuong (03/06/2021)
     */
    getParentAccountNumber() {
      const path = ".MISAAccount-System .Root .Row.selected .AccountNumber";
      const target = document.querySelector(path);
      if (!target) {
        return null;
      }
      const result = target.innerHTML.trim();
      return result;
    },
  },
};
</script>

<style lang="scss">
.MISAAccount-System {
  position: relative;
  overflow: scroll;
  flex-direction: column;
  height: calc(100vh - 50px);
  padding: 0px 30px 0px 20px;
}

.MISAAccount-System-Head {
  position: sticky;
  top: 0;
  left: 0;
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  height: 93px;
  padding: 22px 0 16px;
  background-color: #f4f5f6;
  z-index: 1001;
  .MISAAccount-System-Head-ASList {
    .title {
      font-size: 24px;
      font-weight: 700;
      color: #111;
    }
    .back-to-all {
      .icon {
        display: inline-block;
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -226px -357px;
        cursor: pointer;
      }
      a {
        color: #0075c0;
      }
    }
  }
}

.MISAAccount-System-Head-Button {
  display: flex;
  align-items: center;
  .btn {
    height: 36px;
    padding: 8px 20px;
    border-radius: 30px;
    cursor: pointer;
  }
  .btn-change-account {
    border: 1px solid #8d9096;
    background-color: transparent;
    color: #111;
    font-weight: 600;
    &:hover {
      background-color: #d2d3d6;
    }
  }
  .btn-add {
    border: 1px solid transparent;
    background-color: #2ca01c;
    color: #fff;
    margin-left: 10px;
    &:hover {
      background-color: #35bf22;
    }
  }
}

.Content-Feature {
  position: sticky;
  left: 0;
  display: flex;
  justify-content: space-between;
  height: 73px;
  padding: 16px 16px 10px 16px;
  background-color: #fff;
  .Feature-Left {
    display: flex;
    height: 100%;

    .Feature-Filter {
      position: relative;
      width: 250px;
      height: 32px;
      .Search-input {
        width: 100%;
        height: 100%;
        padding: 0 1.75rem 0 0.85rem;
        border: 1px solid #babec5;
        border-radius: 2px;
        outline: none;
        &:focus {
          border-color: #2ca01c;
        }
        &::placeholder {
          font-style: italic;
        }
      }
      .icon {
        position: absolute;
        top: 50%;
        right: 10px;
        transform: translateY(-50%);
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -992px -360px;
        cursor: pointer;
      }
    }
  }
  .Feature-Right {
    display: flex;
    align-items: center;
    .Icon {
      width: 24px;
      height: 24px;
      margin: 0 6px;
      background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
      cursor: pointer;
    }
    .Shorten {
      height: 24px;
      font-size: 13px;
      color: #0075c0;
      margin-top: 3px;
      margin-right: 12px;
      cursor: pointer;
    }
    .Feature-Reload {
      background-position: -423px -200px;
    }
    .Feature-Export-Excel {
      background-position: -704px -200px;
    }
  }
}

.MISAAccount-System-Content {
  .MISAAccount-System-Content-Table {
    .MISANode {
      position: relative;
      padding-left: 20px;
      background-color: #fff;
      .icon {
        position: absolute;
        top: 15px;
        left: 28px;
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -607px -311px;
        cursor: pointer;
      }
    }
    .Thead,
    .Tbody {
      .Row {
        // display: flex;
        white-space: nowrap;
        height: 34px;
        .Column {
          // display: flex;
          // align-items: center;
          display: inline-block;
          line-height: 34px;
          width: 150px;
          height: 100% !important;
          padding: 0 10px;
          border-right: 1px solid #c7c7c7;
          border-bottom: 1px solid #c7c7c7;
          background-color: #eceef1;
          &.AccountName,
          &.EnglishName {
            width: 250px;
          }
          &.Kind {
            width: 100px;
          }
          &.Status {
            width: 140px;
          }
          &.Feature {
            width: 140px;
            border-left: 1px solid #c7c7c7;
          }
          &.Explain {
            width: 270px;
          }
        }
      }
    }
    .Thead {
      position: sticky;
      top: 90px;
      white-space: nowrap;
      z-index: 1000;
      .Column {
        font-size: 12px;
        font-weight: 600;
      }
    }
    .Tbody {
      .Row {
        height: 46.6px;
        white-space: nowrap;
        cursor: pointer;
        // overflow: hidden;
        .Column {
          background-color: #fff;
          line-height: 46.6px;
          &.AccountNumber {
            padding-left: 28px;
          }
        }
        &.selected {
          .Column {
            background-color: #f3f8f8;
          }
        }
        &:hover {
          .Column {
            background-color: #f3f8f8;
          }
        }
      }
      .Feature {
        .Wrapper {
          display: flex;
          align-items: center;
          padding-left: 16px;
          .Text {
            margin-right: 10px;
            font-weight: 600;
            color: #0075c0;
          }
          .Icon {
            position: relative;
            width: 16px;
            height: 16px;
            background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
            background-position: -896px -359px;
          }
        }
      }
    }
    .Feature {
      position: sticky;
      right: 0;
      z-index: 999;
    }
  }
}

.MISAAccount-System-Content {
  .Data-Pagenav {
    position: fixed;
    bottom: 10px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: calc(100% - 245px);
    height: 48px;
    padding: 0 16px;
    background-color: #fff;
    z-index: 1000;
  }
}
</style>
