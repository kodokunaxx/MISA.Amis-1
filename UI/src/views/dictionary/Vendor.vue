<template>
  <div class="MISAVendor" ref="content">
    <!-- <BaseLoading :showLoading="isLoading" /> -->
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
        <div class="btn">
          Thêm
          <div class="line"></div>
          <span class="icon add"></span>
        </div>
      </div>
    </div>

    <div class="MISAVendor-Content">
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
        <table border="0" cellspacing="0" width="100%" id="Data-Table">
          <thead ref="dataHead">
            <th class="td-left-16"></th>
            <th class="Checbox sticky-left left-16 justify-center">
              <input type="checkbox" class="right-5 m-b-5" />
            </th>
            <th class="VendorCode">Mã nhà cung cấp</th>
            <th class="VendorName">Tên nhà cung cấp</th>
            <th class="Address">Địa chỉ</th>
            <th class="Debt text-right">Công nợ</th>
            <th class="TaxCode">Mã số thuế</th>
            <th class="PhoneNumber">Điện thoại</th>
            <th class="Feature sticky-right text-center">Chức năng</th>
            <th class="td-white-30"></th>
            <th class="td-grey-30"></th>
          </thead>
          <tbody>
            <tr v-for="i in 20" :key="i">
              <td class="td-left-16"></td>
              <td class="Checkbox sticky-left left-16 justify-center">
                <input type="checkbox" class="right-5" />
              </td>
              <td class="VendorCode">123</td>
              <td class="VendorName">123</td>
              <td class="Address">Ngõ 10000000000000000000</td>
              <td class="Debt text-right">123</td>
              <td class="TaxCode">123</td>
              <td class="PhoneNumber">03332495959</td>
              <td
                class="Feature sticky-right flex text-center items-center justify-center"
              >
                <div class="wrapper">
                  <div class="text">Sửa</div>
                  <div class="icon" @click="openContextMenu($event)"></div>
                </div>
              </td>
              <td class="td-white-30"></td>
              <td class="td-grey-30"></td>
            </tr>
          </tbody>
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
        </table>
        <div class="Arrow" @click="handleContentHead()">
          <div class="icon" ref="arrow"></div>
        </div>
      </div>
    </div>
    <ContextMenu ref="menu">
      <ul>
        <li>Nhân bản</li>
        <li>Xoá</li>
        <li>Ngưng sử dụng</li>
      </ul>
    </ContextMenu>
  </div>
</template>

<script>
import ContextMenu from "../../components/base/ContextMenu";
export default {
  components: {
    ContextMenu,
  },
  created() {
    document.title = "Nhà cung cấp";
  },
  mounted() {},
  data() {
    return {
      isShowContenHead: true,
    };
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
  },
};
</script>

<style lang="scss">
.MISAVendor {
  overflow: scroll;
  flex-direction: column;
}

.MISAVendor .MISAVendor-Head {
  justify-content: space-between;
  left: 0;
  width: 100%;
  padding: 15px 0px 15px 0px;
  position: sticky;
  top: 0;
  z-index: 10;
  background-color: #f4f5f6;
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

.MISAVendor .MISAVendor-Content {
  min-width: 100%;
  .MISAVendor-Content-Head {
    display: flex;
    justify-content: space-between;
    margin-bottom: 20px;
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
  .MISAVendor-Content-Body {
    position: relative;
    margin-top: 16px;
    .Body-Feature {
      display: flex;
      justify-content: space-between;
      height: 73px;
      padding: 16px 16px 10px 16px;
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
    }
    #Data-Table {
      th {
        height: 34.6px;
        padding: 5px 10px 3px;
        z-index: 1;
      }
      td {
        height: 46px;
        padding: 5px 10px 3px;
        z-index: 1;
      }
      .Debt {
        text-align: right !important;
      }
      .Feature {
        border-left: 1px solid #e0e0e0 !important;
      }
      tbody {
        .Feature {
          border-left: 1px solid #e0e0e0 !important;
          .wrapper {
            position: relative;
            display: flex;
            justify-content: center;
            align-items: center;
            cursor: pointer;
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
              background-position: -894px -359px;
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
</style>
