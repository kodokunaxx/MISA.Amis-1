<template>
  <div class="MISAVendor">
    <div class="MISAVendor-Head flex items-center">
      <div class="MISAVendor-Head-VendorList">
        <div class="title">Danh sách nhà cung cấp</div>
        <div class="back-to-all">
          <span class="icon"></span>
          <a href="#">
            Tất cả các danh mục
          </a>
        </div>
      </div>
      <div class="MISAVendor-Head-Button">
        <div class="btn">
          <span class="icon guide"></span>
          <a href="#">Hướng dẫn</a>
        </div>
        <div class="btn">
          Tiện ích
          <span class="icon utility"></span>
        </div>
        <div class="btn" @click="openDialog()">
          Thêm
          <div class="line"></div>
          <span class="icon add"></span>
        </div>
      </div>
    </div>

    <div class="MISAVendor-Content-Head" v-show="isShowContenHead">
      <div class="Out-of-date">
        <div class="wrapper">
          <div>0</div>
          <div>Nợ quá hạn</div>
        </div>
      </div>
      <div class="Total">
        <div class="wrapper">
          <div>0</div>
          <div>Tổng nợ phải trả</div>
        </div>
      </div>
      <div class="Paid">
        <div class="wrapper">
          <div>0</div>
          <div>Đã thanh toán (30 ngày gần đây)</div>
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
          />
          <div class="icon"></div>
        </div>
        <div class="Icon Feature-Reload" title="Lấy lại dữ liệu" @click="reload()"></div>
        <div class="Icon Feature-Export-Excel" title="Xuất ra Excel"></div>
        <div class="Icon Feature-Setting" title="Tùy chỉnh giao diện"></div>
      </div>
      <div class="Arrow" @click="handleContentHead()">
        <div class="icon" ref="arrow"></div>
      </div>
    </div>
    <div class="MISAVendor-Content-Body">
      <div id="Data-Table">
        <div class="Thead">
          <div class="Row">
            <div class="Column Checkbox"><input type="checkbox" /></div>
            <div class="Column VendorCode">Mã nhà cung cấp</div>
            <div class="Column VendorName">Tên nhà cung cấp</div>
            <div class="Column Address">Địa chỉ</div>
            <div class="Column Debt text-right">Công nợ</div>
            <div class="Column TaxCode">Mã số thuế</div>
            <div class="Column PhoneNumber">Điện thoại</div>
            <div class="Column IdCard">Số CMND</div>
            <div class="Column Feature">Chức năng</div>
          </div>
        </div>
        <div class="Tbody">
          <div
            v-for="vendor in this.$store.getters.getVendors"
            :key="vendor.VendorId"
            @dblclick="openDialog(vendor.VendorId, 'UPDATE')"
            :id="vendor.VendorId"
            class="Row"
          >
            <div class="Column Checkbox"><input type="checkbox" /></div>
            <div class="Column VendorCode">{{ vendor.VendorCode }}</div>
            <div class="Column VendorName">{{ vendor.VendorName }}</div>
            <div class="Column Address">{{ vendor.Address }}</div>
            <div class="Column Debt text-right">
              {{ vendor.Debt | formatMoney }}
            </div>
            <div class="Column TaxCode">{{ vendor.TaxCode }}</div>
            <div class="Column PhoneNumber">{{ vendor.PhoneNumber }}</div>
            <div class="Column IdCard">{{ vendor.IdCard }}</div>
            <div class="Column Feature ">
              <div class="wrapper">
                <div class="text">Lập CT mua hàng</div>
                <div class="icon" @click="openContextMenu($event)"></div>
              </div>
            </div>
          </div>
        </div>
        <div class="Data-Pagenav">
          <div class="Data-Pagenav-Left">
            <div class="Total-Row">Tổng số: 21 bản ghi</div>
          </div>
          <div class="Data-Pagenav-Right">
            <select class="Selection">
              <option value="10">10 bản ghi trên 1 trang</option>
              <option value="20">20 bản ghi trên 1 trang</option>
              <option value="30">30 bản ghi trên 1 trang</option>
              <option value="50">50 bản ghi trên 1 trang</option>
              <option value="100">100 bản ghi trên 1 trang</option>
            </select>
            <div class="Prev">Trước</div>
            <div class="Page-Index">
              <div value="1">1</div>
              <div value="2" class="active">2</div>
              <div value="3">3</div>
            </div>
            <div class="Next">Sau</div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading v-if="this.$store.getters.getIsLoading" />
    <ContextMenu ref="menu">
      <ul>
        <li>Xem</li>
        <li>Sửa</li>
        <li>Xóa</li>
      </ul>
    </ContextMenu>
    <VendorDialog
      v-if="isShowVendorDialog"
      @closeDialog="closeDialog()"
      @rebind="bindDataToForm(vendor.data.Data)"
      @reloadData="reload()"
    />
  </div>
</template>

<script>
import ContextMenu from "../../components/base/ContextMenu";
import BaseLoading from "../../components/base/BaseLoading";
import VendorDialog from "../../components/dialog/vendor/VendorDialog";
import axios from "axios";

export default {
  components: {
    ContextMenu,
    BaseLoading,
    VendorDialog,
  },
  created() {
    document.title = "Nhà cung cấp";
    this.getVendors(); // Lấy dữ liệu vendors
  },
  mounted() {},
  data() {
    return {
      isShowContenHead: true,
      isShowVendorDialog: false,
      API_URL: this.$store.getters.getApiUrl + "/vendors",
      vendor: null,
    };
  },
  filters: {
    formatMoney(value) {
      if (!value) return "";

      const regex = /\B(?=(\d{3})+(?!\d))/g;
      return value.toString().replace(regex, ".");
    },
  },
  methods: {
    /**
     * Lấy dữ liệu nhà cung cấp
     * CreateBy: nvcuong(29/05/2021)
     */
    getVendors() {
      this.$store.dispatch("setVendors");
    },

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
     * Hiện context menu
     * @param e Event
     * @param item dữ liệu nv
     * CreatedBy: nvcuong(26/05/2021)
     */
    openContextMenu(e, item) {
      this.dataContext = {};
      this.dataContext = item;
      this.$refs.menu.open(e);
    },

    /**
     * Mở dialog
     * CreatedBy: nvcuong(26/05/2021)
     */
    async openDialog(id, MODE) {
      if (MODE == null) {
        // null nếu mở bằng nút thêm
        this.$store.commit("setMODE", "ADD"); // set MODE là ADD
      } else {
        this.$store.commit("setMODE", "UPDATE");
      }

      // const vm = this;
      if (id != null) {
        this.isShowVendorDialog = true; // Mở dialog
        this.$store.commit("setIsLoading", true); // Bật loading effect
        this.$store.commit("setIsOrganization", true); // Mặc định là mode tổ chức

        this.vendor = await this.getVendorById(id);
        const data = this.vendor.data.Data;

        this.bindDataToForm(data); // Đẩy dữ liệu lên form
        this.$store.commit("setIsLoading", false); // Tắt loading effect
      } else {
        await this.$store.commit("setIsOrganization", true); // mặc định là mode tổ chức
        this.isShowVendorDialog = true; // Mở dialog
      }
    },
    /**
     * Đóng dialog
     * CreatedBy: nvcuong(26/05/2021)
     */
    closeDialog() {
      this.isShowVendorDialog = false;
    },

    /**
     * Lấy dữ liệu qua id
     * CreatedBy: nvcuong(29/05/2021)
     */
    async getVendorById(id) {
      console.log("%c[MSG][From Vendor]: GET BY ID", "color: blue");
      try {
        return axios.get(this.API_URL + `/${id}`);
      } catch (error) {
        console.log("%c[ERROR][From Vendor]:", "color: red", error);
      }
    },

    /**
     * Bind dữ liệu lên form
     * CreatedBy: nvcuong(29/05/2021)
     */
    bindDataToForm(data) {
      const keys = Object.keys(data);

      keys.forEach((key) => {
        const path = `.MISAVendor-Dialog input[field="${key}"], textarea[field="${key}"]`;
        const input = document.querySelector(path);
        if (input) {
          input.value = data[key];
        }
      });
    },
    /**
     * Reload lại dữ liệu
     * CreatedBy: nvcuong(29/05/2021)
     */
    reload() {
      this.$store.commit("setIsLoading", true);
      this.getVendors();
    },

  },
};
</script>

<style lang="scss">
.MISAVendor {
  position: relative;
  overflow: scroll;
  flex-direction: column;
  height: calc(100vh - 50px);
  padding: 0px 30px 0px 20px;
}

.MISAVendor-Head {
  position: sticky;
  top: 0;
  left: 0;
  justify-content: space-between;
  width: 100%;
  height: 83px;
  padding: 15px 0px 15px 0px;
  margin-bottom: 20px;
  background-color: #f4f5f6;
  z-index: 10;
}

.MISAVendor-Head-VendorList {
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
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
      background-position: -226px -357px;
      cursor: pointer;
    }
    a {
      color: #0075c0;
    }
  }
}

.MISAVendor-Head-Button {
  display: flex;
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
      width: 120px;
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
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
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

.MISAVendor-Content-Head {
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
        background-color: #b8bcc3;
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
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
      background-position: -256px -130px;
      cursor: pointer;
    }
    .Feature-Execute,
    .Feature-Multiple-Filter {
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
        background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
          no-repeat;
        background-position: -560px -355px;
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
        background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
          no-repeat;
        background-position: -992px -360px;
        cursor: pointer;
      }
    }
    .Icon {
      width: 24px;
      height: 100%;
      margin: 0 6px;
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
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
    right: 0;
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
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
      background-position: -131px -355px;
    }
  }
}

.MISAVendor-Content-Body {
  #Data-Table {
    // margin: 0 32px 0 16px;
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
          &.VendorCode {
            width: 180px;
          }
          &.VendorName,
          &.Address {
            width: 250px;
          }
          &.Debt,
          &.TaxCode,
          &.PhoneNumber,
          &.IdCard {
            width: 150px;
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
      top: 83px;
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
      }

      .Feature {
        border-left: 1px solid #e0e0e0 !important;
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
            background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
              no-repeat;
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
        &.Next {
          margin: 0 0 0 6.5px;
        }
      }
    }
  }
}
</style>
