<template>
  <div class="MISARPL">
    <div class="MISARPL-Head flex items-center">
      <ul class="MISARPL-Head-Nav">
        <li><router-link to="/"> Quy trình</router-link></li>
        <li class="active">
          <router-link to="/receipt-payment"> Thu, chi tiền</router-link>
        </li>
        <li><router-link to="/#"> Kiểm kê</router-link></li>
        <li><router-link to="/#"> Dự báo dòng tiền</router-link></li>
        <li><router-link to="/#"> Báo cáo</router-link></li>
      </ul>
      <div class="MISARPL-Head-RPL">
        <div class="title">Thu chi tiền mặt</div>
      </div>
      <div class="MISARPL-Head-Button">
        <div class="btn">
          <span class="icon guide"></span>
          <a href="#">Hướng dẫn</a>
        </div>
        <div class="btn">
          Tiện ích
          <span class="icon utility"></span>
        </div>
        <div class="btn" @click="openDialog()">
          Thêm chi tiền
          <div class="line"></div>
          <span class="icon add"></span>
        </div>
      </div>
    </div>

    <div class="MISARPL-Content-Head" v-show="isShowContenHead">
      <div class="Out-of-date">
        <div class="wrapper">
          <div>270.100.644,0</div>
          <div>Tổng thu đầu năm đến hiện tại</div>
        </div>
      </div>
      <div class="Total">
        <div class="wrapper">
          <div>185.100.644,0</div>
          <div>Tổng chi đầu năm đến hiện tại</div>
        </div>
      </div>
      <div class="Paid">
        <div class="wrapper">
          <div style="color: red">(899.800.000,0)</div>
          <div>Tồn quỹ hiện tại</div>
        </div>
      </div>
    </div>
    <div class="Body-Feature">
      <div class="Feature-Left">
        <div class="Feature-Arrow"></div>
        <div class="Feature-Execute">
          Thực thi hàng loạt
          <span class="icon"></span>
        </div>
        <div class="Feature-Multiple-Filter">
          Lọc
          <span class="icon"></span>
        </div>
      </div>
      <div class="Feature-Right">
        <div class="Feature-Filter">
          <input
            type="text"
            class="Search-input"
            placeholder="Nhập để tìm kiếm"
            ref="search"
            @keyup="searchRP($event.target.value)"
          />
          <div class="icon"></div>
        </div>
        <div
          class="Icon Feature-Reload"
          title="Lấy lại dữ liệu"
          @click="reload()"
        ></div>
        <div class="Icon Feature-Export-Excel" title="Xuất ra Excel"></div>
        <div class="Icon Feature-Setting" title="Tùy chỉnh giao diện"></div>
      </div>
      <div class="Arrow" @click="handleContentHead()">
        <div class="icon" ref="arrow"></div>
      </div>
    </div>
    <div class="MISARPL-Content-Body">
      <div id="Data-Table">
        <div class="Thead">
          <div class="Row">
            <div class="Column Checkbox"><input type="checkbox" /></div>
            <div class="Column KBADate text-center">NGÀY HẠCH TOÁN</div>
            <div class="Column VoucherDate text-center">NGÀY CHỨNG TỪ</div>
            <div class="Column VoucherNumber">SỐ CHỨNG TỪ</div>
            <div class="Column Explain">DIỄN GIẢI</div>
            <div class="Column Money text-right">SỐ TIỀN</div>
            <div class="Column VendorName">ĐỐI TƯỢNG</div>
            <div class="Column VendorCode">MÃ ĐỐI TƯỢNG</div>
            <div class="Column Address">ĐỊA CHỈ</div>
            <div class="Column Feature">CHỨC NĂNG</div>
          </div>
        </div>
        <div class="Tbody">
          <div
            v-for="rp in this.$store.getters.getRPL"
            :key="rp.ReceiptPaymentId"
            @dblclick="openDialog(rp.ReceiptPaymentId, 'UPDATE')"
            @click="handleSelectRow(rp.ReceiptPaymentId)"
            :id="rp.ReceiptPaymentId"
            class="Row"
          >
            <div class="Column Checkbox"><input type="checkbox" /></div>
            <div class="Column KBADate text-center">
              {{ rp.KBADate | formatDate }}
            </div>
            <div class="Column VoucherDate text-center">
              {{ rp.VoucherDate | formatDate }}
            </div>
            <div class="Column VoucherNumber">{{ rp.VoucherNumber }}</div>
            <div class="Column Explain">{{ rp.Explain }}</div>
            <div class="Column Money text-right">
              {{ rp.Money | formatMoney }}
            </div>
            <div class="Column VendorName">{{ rp.VendorName }}</div>
            <div class="Column VendorCode">{{ rp.VendorCode }}</div>
            <div class="Column Address">{{ rp.Address }}</div>
            <div class="Column Feature ">
              <div class="wrapper">
                <div class="text">Xem</div>
                <div class="icon" @click="openContextMenu($event)"></div>
              </div>
            </div>
          </div>
        </div>
        <div class="Data-Pagenav">
          <div class="Data-Pagenav-Left">
            <div class="Total-Row">
              Tổng số:
              <span style="font-weight: 600">{{
                $store.getters.getTotalRPL
              }}</span>
              bản ghi
            </div>
          </div>
          <div class="Data-Pagenav-Right">
            <Pagenav @setPageSize="setPageSize($event)" />
            <div
              class="Prev"
              @click="decreasePageIndex()"
              :class="[this.$store.getters.getPageIndex == 1 ? 'disable' : '']"
            >
              Trước
            </div>
            <div class="Page-Index">
              <div
                v-show="parseInt(this.$store.getters.getPageIndex) - 1 > 0"
                @click="setPageIndex($event.target.innerHTML)"
              >
                {{ parseInt(this.$store.getters.getPageIndex) - 1 }}
              </div>

              <div
                class="active"
                @click="setPageIndex($event.target.innerHTML)"
              >
                {{ this.$store.getters.getPageIndex }}
              </div>

              <div
                v-show="
                  Math.ceil(
                    this.$store.getters.getTotalRPL /
                      this.$store.getters.getPageSize
                  ) >=
                    parseInt(this.$store.getters.getPageIndex) + 1
                "
                @click="setPageIndex($event.target.innerHTML)"
              >
                {{ parseInt(this.$store.getters.getPageIndex) + 1 }}
              </div>
            </div>
            <div
              class="Next"
              @click="increasePageIndex()"
              :class="[
                this.$store.getters.getPageIndex ==
                Math.ceil(
                  this.$store.getters.getTotalRPL /
                    this.$store.getters.getPageSize
                )
                  ? 'disable'
                  : '',
              ]"
            >
              Sau
            </div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading v-if="this.$store.getters.getIsLoading" />

    <ContextMenu ref="menu" v-show="isShowContextMenu" :w="100">
      <ul>
        <li @click="closeContextMenu(), viewRPInfo()">Xem</li>
        <li @click="closeContextMenu(), confirmDelete()">Xóa</li>
        <li @click="closeContextMenu(), duplicateRP()">Nhân bản</li>
      </ul>
    </ContextMenu>

    <Popup v-if="this.$store.getters.getIsShowConfirmDelete">
      <template v-slot:Head>
        <div class="icon-popup icon-dangerous"></div>
        <div class="text">
          Bạn có thực sự muốn xóa Phiếu thu chi {{ VoucherNum }} không?
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
              @click="deleteRP(getId()), closeConfirmDelete()"
            >
              Có
            </button>
          </div>
        </div>
      </template>
    </Popup>

    <ReceiptPaymentDialog
      v-if="this.$store.getters.getIsShowRPDialog"
      @reload="reload()"
    />
  </div>
</template>

<script>
import ReceiptPaymentDialog from "../../components/dialog/receipt-payment/ReceiptPaymenDialog";
import ContextMenu from "../../components/base/ContextMenu";
import BaseLoading from "../../components/base/BaseLoading";
import Popup from "../../components/base/Popup";
import Pagenav from "../../components/base/Pagenav";
import axios from "axios";

export default {
  components: {
    ReceiptPaymentDialog,
    ContextMenu,
    BaseLoading,
    Popup,
    Pagenav,
    // isShowContextMenu: false,
  },
  async created() {
    document.title = "Tiền mặt";
    await this.$store.commit("resetState"); // reset state
    this.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
    await this.$store.dispatch("setRPL"); // Lấy dữ liệu thu chi
  },
  data() {
    return {
      isShowContenHead: true,
      API_URL: this.$store.getters.getApiUrl,
      isShowContextMenu: false,
      delayTimer: null,
      pageSize: 20,
      VoucherNum: null,
    };
  },
  filters: {
    formatMoney(value) {
      if (!value) return "";

      const regex = /\B(?=(\d{3})+(?!\d))/g;
      return value.toString().replace(regex, ".");
    },
    formatDate(date) {
      let dob = new Date(date);
      if (dob.toString() === "Invalid Date") {
        /* nếu ngày tháng không hợp lệ, return ""*/
        return "";
      }

      let day = dob.getDate(),
        month = dob.getMonth() + 1,
        year = dob.getFullYear();

      /*format lại day và month nếu < 10, example: 4 => 04 */
      day = day < 10 ? "0" + day : day;
      month = month < 10 ? "0" + month : month;

      return day + "/" + month + "/" + year;
    },
  },
  methods: {
    /**
     * Handle click ẩn/hiện Content head
     * CreateBy: nvcuong(26/05/2021)
     */
    handleContentHead() {
      this.isShowContenHead = !this.isShowContenHead;
      if (this.isShowContenHead) {
        this.$refs.arrow.style.backgroundPosition = "-131px -355px";
      } else {
        this.$refs.arrow.style.backgroundPosition = "-179px -356px";
      }
    },
    /**
     * Mở dialog
     * CreatedBy: nvcuong(26/05/2021)
     */
    async openDialog(id, MODE) {
      try {
        this.$store.commit("setIsLoading", true); // Bật loading effect
        await this.$store.dispatch("setVendors"); // Lấy dữ liệu NCC
        await this.$store.dispatch("setAccounts"); // Lấy dữ liệu tài khoản

        if (MODE == null || MODE == "ADD") {
          // null nếu mở bằng nút thêm
          this.$store.commit("setMODE", "ADD"); // set MODE là ADD
        } else {
          this.$store.commit("setMODE", "UPDATE");
        }

        // const vm = this;
        if (id != null) {
          this.$store.commit("setIsShowRPDialog", true); // Mở dialog
          this.$store.commit("setIsLoading", false); // Tắt loading effect
          const RP = await this.getRPById(id);
          const data = RP.data.Data;

          this.bindDataToForm(data); // Đẩy dữ liệu lên form
        } else {
          this.$store.commit("setIsShowRPDialog", true);
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Bind dữ liệu lên form
     * CreatedBy: nvcuong(29/05/2021)
     */
    bindDataToForm(data) {
      const keys = Object.keys(data);

      keys.forEach((key) => {
        const path = `.MISARP-Dialog input[field="${key}"], textarea[field="${key}"]`;
        const input = document.querySelector(path);
        if (input) {
          input.value = data[key];
        }
      });
      const KBADate = document.querySelector(
        '.MISARP-Dialog input[field="KBADate"]'
      );
      const VoucherDate = document.querySelector(
        '.MISARP-Dialog input[field="VoucherDate"]'
      );

      data["KBADate"] = new Date(data["KBADate"]);
      data["VoucherDate"] = new Date(data["VoucherDate"]);
      data["KBADate"].setDate(data["KBADate"].getDate() + 1);
      data["VoucherDate"].setDate(data["VoucherDate"].getDate() + 1);

      KBADate.valueAsDate = new Date(data["KBADate"]);
      VoucherDate.valueAsDate = new Date(data["VoucherDate"]);

      const accountNumbers = document.querySelectorAll(
        '.MISARP-Dialog input[field="AccountNumber"]'
      );
      accountNumbers.forEach(
        (accountNumber) => (accountNumber.value = data["AccountNumber"])
      );
    },

    /**
     * Lấy dữ liệu qua id
     * CreatedBy: nvcuong(29/05/2021)
     */
    async getRPById(id) {
      console.log("%c[MSG]: GET BY ID", "color: blue");
      try {
        return axios.get(this.API_URL + `/receiptpayments/${id}`);
      } catch (error) {
        console.log("%c[ERROR]:", "color: red", error);
      }
    },

    /**
     * Reload lại dữ liệu
     * CreatedBy: nvcuong (05/06/2021)
     */
    async reload() {
      this.$store.commit("setIsLoading", true);
      await this.$store.dispatch("setRPL");
    },

    /**
     * Hiện context menu
     * @param e Event
     * @param item dữ liệu nv
     * CreatedBy: nvcuong(26/05/2021)
     */
    openContextMenu(e, item) {
      this.dataContext = {};
      this.dataContext = item;
      this.isShowContextMenu = true;
      this.$refs.menu.open(e);
    },
    /**
     * Đóng context menu
     * CreatedBy: nvcuong(31/05/2021)
     */
    closeContextMenu() {
      this.isShowContextMenu = false;
    },

    /**
     * Xử lí khi chọn 1 row
     * CreateBy: nvcuong(29/05/2021)
     */
    handleSelectRow(id) {
      let path = ".MISARPL .Row.selected";
      const currentRowSelected = document.querySelector(path);

      if (currentRowSelected) {
        currentRowSelected.classList.remove("selected");
      }
      path = `.MISARPL div[id="${id}"]`;
      document.querySelector(path).classList.add("selected");

      this.VoucherNum = document.querySelector(
        path + " .VoucherNumber"
      ).innerHTML;
    },

    getId() {
      const path = ".MISARPL .Row.selected";
      const selectedInput = document.querySelector(path);
      if (selectedInput) {
        return selectedInput.attributes.id.value;
      }
    },

    /**
     * Xóa phiếu thu, chi
     * CreatedBy: nvcuong(31/05/2021)
     */
    deleteRP(id) {
      const vm = this;
      try {
        this.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
        if (!id) {
          const path = ".MISARP .Row.selected";
          id = document.querySelector(path).attributes.id.value;
        }
        const API_URL = this.API_URL + "/receiptpayments/" + id;
        axios
          .delete(API_URL)
          .then(() => {
            vm.reload(); // Load lại khi xóa thành công
          })
          .catch((error) => console.log(error.response));
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hiện thông báo confirm trước khi xóa
     * CreatedBy: nvcuong (31/05/2021)
     */
    confirmDelete() {
      this.$store.commit("setIsShowConfirmDelete", true);
    },

    /**
     * Đóng thông báo confirm sau khi xóa
     * CreatedBy: nvcuong (31/05/2021)
     */
    closeConfirmDelete() {
      this.$store.commit("setIsShowConfirmDelete", false);
    },

    /**
     * Read only
     * CreatedBy: nvcuong(31/05/2021)
     */
    async viewRPInfo() {
      await this.$store.commit("setIsReadOnly", true);
      this.openDialog(this.getId());
    },

    /**
     * Nhân bản
     * CreatedBy: nvcuong (05/06/2021)
     */
    async duplicateRP() {
      await this.openDialog(this.getId(), "ADD");
      await this.$store.dispatch("setNewVoucherNumber");
      const voucherNumberField = document.querySelector(
        '.MISARP-Dialog input[field="VoucherNumber"]'
      );
      voucherNumberField.value = this.$store.getters.getNewVoucherNumber;
    },
    /**
     * Cài đặt page size
     * CreatedBy: nvcuong (31/05/2021)
     */
    async setPageSize(size) {
      await this.$store.commit("setPageSize", size);
      this.searchRP(this.$refs.search.value);
      this.$store.commit("setPageIndex", 1);
    },

    /**
     * Cài đặt page index
     * CreatedBy: nvcuong (31/05/2021)
     */
    async setPageIndex(index) {
      await this.$store.commit("setPageIndex", index);
      this.searchRP(this.$refs.search.value);
    },

    increasePageIndex() {
      const currentPageIndex = parseInt(this.$store.getters.getPageIndex);

      const max = Math.ceil(
        this.$store.getters.getTotalRPL / this.$store.getters.getPageSize
      );
      if (currentPageIndex < max) this.setPageIndex(currentPageIndex + 1);
    },

    decreasePageIndex() {
      const currentPageIndex = parseInt(this.$store.getters.getPageIndex);
      if (currentPageIndex > 1) this.setPageIndex(currentPageIndex - 1);
    },

    /**
     * Tìm kiếm qua keywords
     * CreateBy: nvcuong(31/05/2021)
     */
    searchRP(keywords) {
      const vm = this;
      clearTimeout(this.delayTimer);

      this.delayTimer = setTimeout(function() {
        vm.$store.commit("setIsLoading", true); // Bật hiệu ứng loading
        vm.$store.dispatch("setRPFilter", keywords); // Tìm kiếm
      }, 500);
    },
  },
};
</script>

<style lang="scss">
.MISARPL {
  position: relative;
  overflow: scroll;
  flex-direction: column;
  height: calc(100vh - 50px);
  padding: 0px 30px 0px 20px;
}

.MISARPL-Head {
  position: sticky;
  top: 0;
  left: 0;
  flex-wrap: wrap;
  justify-content: space-between;
  width: 100%;
  height: 144px;
  padding: 10px 0px 15px 0px;
  margin-bottom: 10px;
  background-color: #f4f5f6;
  z-index: 10;
  .MISARPL-Head-Nav {
    flex-basis: 100%;
    display: flex;
    align-items: flex-end;
    height: 58px;
    border-bottom: 2px solid #d4d7dc;
    li {
      display: inline-block;
      padding: 0 20px 10px 20px;
      cursor: pointer;
      border-bottom: 4px solid transparent;
      a {
        color: #111;
      }
      &.active {
        border-bottom-color: #2ca01c;
        a {
          color: #111;
          font-weight: 700;
          font-size: 13px;
        }
      }
      &:hover {
        a {
          color: #2ca01c;
        }
      }
    }
  }

  .MISARPL-Head-RPL {
    padding-top: 15px;
    .title {
      font-size: 24px;
      font-weight: 700;
      color: #212121;
    }
  }

  .MISARPL-Head-Button {
    display: flex;
    padding-top: 15px;
    margin-right: 8px;
    .btn {
      display: flex;
      align-items: center;
      width: 100px;
      height: 36px;
      margin-right: 10px;
      cursor: pointer;
      &:first-child:hover {
        a {
          text-decoration: underline;
        }
      }
      &:nth-child(2) {
        display: flex;
        justify-content: center;
        border: 2px solid #3b3c3f;
        border-radius: 30px;
        padding-left: 10px;
        &:hover {
          background-color: #d2d3d6;
        }
      }
      &:last-child {
        width: 158px;
        display: flex;
        justify-content: center;
        padding-left: 10px;
        margin-right: 0;
        border-radius: 30px;
        background-color: #2ca01c;
        color: #fff;
        .line {
          width: 1px;
          height: 20px;
          background-color: #fff;
          margin: 0 10px 0 20px;
        }
        &:hover {
          background-color: #35bf22;
        }
      }
      a {
        color: #0075c0;
      }
      .icon {
        display: inline-block;
        width: 24px;
        height: 24px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        &.guide {
          margin-right: 6px;
          background-position: -984px -144px;
        }
        &.utility {
          margin-left: 10px;
          background-position: -560px -356px;
        }
        &.add {
          background-position: -848px -356px;
        }
      }
    }
  }
}

.MISARPL-Content-Head {
  position: sticky;
  left: 0;
  display: flex;
  justify-content: space-between;
  padding-bottom: 16px;
  background-color: #f4f5f6;
  .Out-of-date,
  .Total,
  .Paid {
    width: 33%;
    .wrapper {
      display: flex;
      align-items: center;
      flex-wrap: wrap;
      height: 67px;
      padding: 10px;
      div {
        flex-basis: 100%;
        color: #fff;
        &:first-child {
          font-size: 24px;
        }
      }
    }
    &.Total {
      .wrapper {
        background-color: #00a9f2;
      }
    }
    &.Out-of-date {
      .wrapper {
        background-color: #ff7f2c;
      }
    }
    &.Paid {
      .wrapper {
        background-color: #74cb2f;
      }
    }
  }
}

.Body-Feature {
  position: sticky;
  left: 0;
  display: flex;
  justify-content: space-between;
  height: 73px;
  padding: 16px 16px 10px 16px;
  margin-top: 16px;
  background-color: #fff;
  .Feature-Left {
    display: flex;
    height: 100%;
    .Feature-Arrow {
      width: 24px;
      height: 100%;
      background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
      background-position: -256px -130px;
      cursor: pointer;
    }
    .Feature-Execute,
    .Feature-Multiple-Filter {
      display: flex;
      align-items: center;
      padding: 0 16px;
      height: 36px;
      margin: 0 10px;
      line-height: 36px;
      border: 2px solid #3b3c3f;
      border-radius: 30px;
      color: #111;
      font-weight: 600;
      cursor: pointer;
      .icon {
        display: inline-block;
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -556px -358px;
      }
      &.Feature-Multiple-Filter {
        margin-left: 0;
        cursor: pointer;
      }
    }
  }
  .Feature-Right {
    display: flex;
    .Feature-Filter {
      position: relative;
      width: 217px;
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
    .Icon {
      width: 24px;
      height: 100%;
      margin: 0 6px;
      background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
      cursor: pointer;
    }
    .Feature-Reload {
      background-position: -423px -195px;
    }
    .Feature-Export-Excel {
      background-position: -704px -195px;
    }
    .Feature-Setting {
      background-position: -88px -195px;
    }
  }
  .Arrow {
    position: absolute;
    top: 0;
    right: 5px;
    transform: translateY(-50%);
    width: 30px;
    height: 28px;
    border: 2px solid #e2e9f2;
    background-color: #f4f5f6;
    cursor: pointer;
    .icon {
      position: absolute;
      top: 0;
      right: 0;
      width: 16px;
      height: 16px;
      background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
      background-position: -131px -355px;
    }
  }
}

.MISARPL-Content-Body {
  #Data-Table {
    .Thead,
    .Tbody {
      .Row {
        height: 34.6px;
        .Column {
          display: inline-block;
          height: 100%;
          padding: 5px 10px 3px;
          border-right: 1px solid #c7c7c7;
          border-bottom: 1px solid #c7c7c7;
          z-index: 999;
          &.Checkbox {
            position: sticky;
            left: 0;
            width: 40px;
            z-index: 5;
            input {
              display: inline-block;
              width: 18px;
              height: 16px;
            }
          }
          &.KBADate,
          &.VoucherDate,
          &.Money,
          &.VendorCode {
            width: 150px;
          }
          &.VendorName {
            width: 230px;
          }
          &.VoucherNumber {
            width: 125px;
          }
          &.Explain,
          &.Address {
            width: 320px;
          }

          &.Feature {
            position: sticky;
            right: 0;
            width: 192px;
            text-align: right;
            z-index: 5;
          }
        }
      }
    }
    .Thead {
      white-space: nowrap;
      position: sticky;
      top: 130px;
      z-index: 998;
      .Column {
        line-height: 26.6px;
        background-color: #eceef1;
        font-weight: 700;
        &.Checkbox,
        &.Feature {
          z-index: 6;
        }
        &.Feature {
          padding-right: 22px;
          border-left: 2px solid #e0e0e0 !important;
        }
      }
    }
    .Tbody {
      background-color: #fff;
      .Row {
        height: 48px;
        white-space: nowrap;
        .Column {
          line-height: 40px;
          background-color: #fff;
          overflow: hidden;
          cursor: pointer;
        }
        &:hover {
          .Column {
            background-color: #f3f8f8 !important;
          }
        }
        &.selected {
          .Column {
            background-color: #f8f8f8 !important;
          }
        }
      }

      .Feature {
        border-left: 2px solid #e0e0e0 !important;
        font-family: inherit;
        font-weight: 600;
        .wrapper {
          position: relative;
          display: flex;
          justify-content: center;
          align-items: center;
          .text {
            color: #0075c0;
            margin-right: 10px;
            cursor: pointer;
          }
          .icon {
            display: inline-block;
            width: 16px;
            height: 16px;
            background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
            background-position: -894px -359px;
            cursor: pointer;
          }
        }
      }
    }
  }
  .Data-Pagenav {
    position: fixed;
    bottom: 10px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: calc(100vw - 245px);
    height: 48px;
    padding: 0 16px;
    background-color: #fff;
    z-index: 100;
    .Data-Pagenav-Right {
      display: flex;
      .Selection {
        height: 36px;
        outline: none;
        padding: 0 10px;
        border: 1px solid #e0e0e0;
        border-radius: 3px;
        cursor: pointer;
      }
      .Page-Index,
      .Prev,
      .Next {
        display: flex;
        align-items: center;
        cursor: pointer;
        &.Page-Index {
          div {
            display: flex;
            justify-content: center;
            align-items: center;
            width: 24px;
            height: 24px;
            padding: 4px;
            &.active {
              margin-top: 5px;
              border: 1px solid #e0e0e0;
              font-weight: 600;
            }
          }
        }
        &.Prev {
          margin: 0 6.5px 0 20px;
        }
        &.Prev.disable {
          cursor: default !important;
          color: #9e9e9e;
        }
        &.Next {
          margin: 0 0 0 6.5px;
        }
        &.Next.disable {
          cursor: default !important;
          color: #9e9e9e;
        }
      }
    }
  }
}
</style>
