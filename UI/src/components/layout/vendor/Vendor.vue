<template>
  <div class="MISAVendor">
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
      <div class="MISAVendor-Content-Head">
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
            <div class="Icon Feature-Reload"></div>
            <div class="Icon Feature-Export-Excel"></div>
            <div class="Icon Feature-Setting"></div>
          </div>
        </div>
        <div class="Data">
          <div class="Flex-scroll">
            <div class="Data-Head">
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  Mã nhà cung cấp
                </div>
                <div class="Column Column-L VendorName">
                  Tên nhà cung cấp
                </div>
                <div class="Column Column-L Address">
                  Địa chỉ
                </div>
                <div class="Column Column-S Debt text-align-right">
                  Công nợ
                </div>
                <div class="Column Column-S TaxCode">
                  Mã số thuế
                </div>
                <div class="Column Column-S PhoneNumber">
                  Điện thoại
                </div>
                <div class="Column Column-M Feature Fixed">
                  Chức năng
                </div>
              </div>
            </div>

            <div class="Data-Body">
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  CuongNguyen
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  CuongNguyen
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  1
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
              <div class="Row">
                <div class="Column Column-SM Select-all Fixed">
                  <div class="checkbox"></div>
                </div>
                <div class="Column Column-M VendorCode">
                  CuongNguyen
                </div>
                <div class="Column Column-L VendorName">
                  2
                </div>
                <div class="Column Column-L Address">
                  2
                </div>
                <div class="Column Column-S Debt text-align-right">
                  3
                </div>
                <div class="Column Column-S TaxCode">
                  3
                </div>
                <div class="Column Column-S PhoneNumber">
                  4
                </div>
                <div class="Column Column-M Feature Fixed">
                  4
                </div>
              </div>
            </div>
            <div class="Data-Pagenav"></div>
          </div>
        </div>
      </div>
      <div class="Arrow">
        <div class="icon"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  created() {
    document.title = "Nhà cung cấp";
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
        border: 1px solid black;
        overflow: auto;
        .Flex-scroll {
          .Data-Head,
          .Data-Body {
            .Row {
              display: flex;
              align-items: center;
              justify-content: center;
              flex-wrap: nowrap;
              .Column {
                height: 34.6px;
                line-height: 34.6px;
                padding: 0 16px 0 10px;
                background-color: #eceef1;
                border-right: 1px solid #c7c7c7;
                border-bottom: 1px solid #c7c7c7;
                text-transform: uppercase;
                font-size: 12px;
                color: #111;
                font-weight: 600;
                &.Column-SM {
                  width: 40px;
                  .checkbox {
                    width: 18px;
                    height: 18px;
                    border: 1px solid #c7c7c7;
                    background-color: #fff;
                    margin: 8px auto;
                  }
                }
                &.Column-S {
                  width: 150px;
                }
                &.Column-M {
                  width: 180px;
                }
                &.Column-L {
                  width: 250px;
                }
              }
              .Feature.Fixed {
                position: sticky;
                top: 0;
                right: 0;
                z-index: 99;
                border-left: 1px solid #c7c7c7;
              }
              .Select-all.Fixed {
                position: sticky;
                top: 0;
                left: 0;
                z-index: 99;
              }
            }
          }
          .Data-Body {
            .Row {
              .Column {
                height: 46px;
                line-height: 46px;
                background-color: #fff;
                overflow: hidden;
                &.Column-SM {
                  .checkbox {
                    margin: 14px auto;
                  }
                }
              }
            }
          }
          .Data-Pagenav {
            position: fixed;
            bottom: 100px;
            width: calc(100vw - 245px);
            height: 48px;
            background-color: red;
            z-index: 100;
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
}
</style>
