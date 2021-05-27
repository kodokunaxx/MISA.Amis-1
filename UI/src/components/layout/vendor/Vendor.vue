<template>
  <div class="MISAVendor" ref="content">
    <div class="MISAVendor-Head">
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
        <div class="btn">
          Thêm
          <div class="line"></div>
          <span class="icon add"></span>
        </div>
      </div>
    </div>
    <div class="MISAVendor-Content">
      <div class="MISAVendor-Content-Head" v-if="isShowContenHead">
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
      <div class="MISAVendor-Content-Body">
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
            <div class="Icon Feature-Reload" title="Lấy lại dữ liệu"></div>
            <div class="Icon Feature-Export-Excel" title="Xuất ra Excel"></div>
            <div class="Icon Feature-Setting" title="Tùy chỉnh giao diện"></div>
          </div>
        </div>
        <div class="Data">
          <table class="Data-Table" cellspacing="0" cellpadding="0" ref="table">
            <thead ref="dataHead">
              <th class="Column-SM Sticky Checkbox">
                <input type="checkbox" />
              </th>
              <th class="Column-M VendorCode">Mã nhà cung cấp</th>
              <th class="Column-L VendorName">Tên nhà cung cấp</th>
              <th class="Column-L Address">Địa chỉ</th>
              <th class="Column-S Debt text-align-right">Công nợ</th>
              <th class="Column-S TaxCode">Mã số thuế</th>
              <th class="Column-S PhoneNumber">Điện thoại</th>
              <th class="Column-M Sticky Feature">Chức năng</th>
            </thead>
            <tbody>
              <tr v-for="i in 20" :key="i">
                <td class="Column-SM Sticky Checkbox">
                  <input type="checkbox" />
                </td>
                <td class="Column-M VendorCode">123</td>
                <td class="Column-L VendorName">CuongNguyen</td>
                <td class="Column-L Address">Bac Ninh</td>
                <td class="Column-S Debt text-align-right">0</td>
                <td class="Column-S TaxCode">12321321321312</td>
                <td class="Column-S PhoneNumber">0333245959</td>
                <td class="Column-M Sticky Feature">
                  <div class="wrapper">
                    <span class="text">Sửa</span>
                    <span
                      class="icon"
                      ref="open"
                      @click="openContextMenu($event)"
                    ></span>
                  </div>
                </td>
              </tr>
            </tbody>
          </table>

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
        <div class="Arrow" @click="handleContentHead()">
          <div class="icon" ref="arrow"></div>
        </div>
      </div>
    </div>
    <ContextMenu />
  </div>
</template>

<script>
import ContextMenu from "../../base/ContextMenu";

export default {
  data() {
    return {
      isShowContenHead: true,
    };
  },
  components: {
    ContextMenu,
  },
  created() {
    document.title = "Nhà cung cấp";
  },
  mounted() {
    this.handleTableScroll();
  },
  methods: {
    /**
     * Handle khi scroll
     * CreateBy: nvcuong(26/05/2021)
     */
    handleTableScroll() {
      const me = this;
      const mainContent = this.$refs.content;
      const dataHead = this.$refs.dataHead;

      mainContent.addEventListener("scroll", function() {
        if (mainContent.scrollTop >= 107) {
          dataHead.style.position = "fixed";
          dataHead.style.top = "137px";
          dataHead.style.zIndex = "101";
        } else {
          dataHead.style.position = "initial";
          dataHead.style.zIndex = "1";
        }
        me.closeContextMenu();
      });
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

    openContextMenu(e) {
      this.$store.commit("setX", e.clientX || e.screenX);
      this.$store.commit("setY", e.clientY || e.screenY);
    },
    closeContextMenu() {
      this.$store.commit("setX", -10000);
      this.$store.commit("setY", -10000);
    },
  },
};
</script>

<style lang="scss">
.MISAVendor {
  height: calc(100vh - 48px);
  overflow: auto;
  padding-left: 20px;
  padding-right: 30px;
  background-color: #f4f5f6;
  .MISAVendor-Head {
    position: sticky;
    top: 0;
    display: flex;
    justify-content: space-between;
    padding: 22px 0 16px 0;
    background-color: #f4f5f6;
    z-index: 100;
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
  }
  .MISAVendor-Content {
    position: relative;
    .MISAVendor-Content-Head {
      display: flex;
      justify-content: space-between;
      padding-bottom: 20px;
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
    .MISAVendor-Content-Body {
      position: relative;
      min-height: 310px;
      margin-top: 14px;
      background-color: #fff;
      .Body-Feature {
        display: flex;
        justify-content: space-between;
        height: 73px;
        padding: 16px 16px 10px 16px;
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
      }
      .Data {
        position: relative;
        display: flex;
        width: 100%;
        min-height: 200px;
        max-height: calc(100% - 263px);
        overflow: auto;
        .Data-Table {
          width: 100%;
          overflow: auto;
          thead {
            th {
              height: 34.6px;
              padding: 5px 10px 3px;
              border-right: 1px solid #c7c7c7;
              border-bottom: 1px solid #c7c7c7;
              background-color: #eceef1;
              white-space: nowrap;
              text-align: left;
              overflow: hidden;
              &.Sticky {
                position: sticky;
                top: 0;
                z-index: 99;
                &.Checkbox {
                  left: 0;
                  input {
                    display: block;
                    width: 18px;
                    height: 18px;
                    margin: 0 auto;
                  }
                }
                &.Feature {
                  right: 0;
                  border-left: 1px solid #c7c7c7;
                  border-right: none;
                }
              }
              &.PhoneNumber {
                border-right: none;
              }
              &.Debt {
                text-align: right;
              }
              &.Feature {
                text-align: center;
              }
            }
          }
          tbody {
            max-height: 100px !important;
            overflow: hidden;
            tr {
              height: 48px;
              td {
                padding: 5px 10px;
                border-right: 1px solid #e0e0e0;
                border-bottom: 1px solid #e0e0e0;
                background-color: #fff;
                &.PhoneNumber {
                  border-right: none;
                }
                &.Feature {
                  .wrapper {
                    position: relative;
                    text-align: center;
                    border: 1px solid red;
                    .text {
                      color: #0075c0;
                      margin-right: 10px;
                    }
                    .icon {
                      display: inline-block;
                      width: 16px;
                      height: 16px;
                      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
                        no-repeat;
                      background-position: -891px -355px;
                    }
                  }
                }
              }
              td.Sticky {
                position: sticky;
                top: 0;
                z-index: 98;
                &.Checkbox {
                  left: 0;
                  input {
                    display: block;
                    width: 18px;
                    height: 18px;
                    margin: 0 auto;
                  }
                }
                &.Feature {
                  right: 0;
                  border-left: 1px solid #c7c7c7;
                  border-right: none;
                }
              }
            }
          }
          thead,
          tbody {
            .Column-SM {
              min-width: 40px;
              max-width: 40px;
            }
            .Column-S {
              min-width: 150px;
              max-width: 150px;
            }
            .Column-M {
              min-width: 180px;
              max-width: 180px;
            }
            .Column-L {
              min-width: 250px;
              max-width: 250px;
            }
          }
        }

        .Data-Pagenav {
          position: fixed;
          bottom: 0px;
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
  }
  @media screen and (max-width: 1366px) {
    .Data-Pagenav {
      width: calc(100vw - 260px) !important;
    }
  }
  /* width */
  ::-webkit-scrollbar {
    width: 0px;
    height: 10px;
  }

  /* Track */
  ::-webkit-scrollbar-track {
    background: #f1f1f1;
  }

  /* Handle */
  ::-webkit-scrollbar-thumb {
    background: #888;
  }

  /* Handle on hover */
  ::-webkit-scrollbar-thumb:hover {
    background: #555;
  }
}
</style>
