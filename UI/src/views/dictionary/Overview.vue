<template>
  <div class="MISAOverview">
    <div class="MISAOverview-Head">
      <div class="Element Process active">
        <router-link to="/">Quy trình</router-link>
      </div>
      <div class="Element Money">
        <router-link to="/receipt-payment">Thu, chi tiền</router-link>
      </div>
    </div>
    <div class="MISAOverview-Content">
      <div class="MISAOverview-Content-Business">
        <div class="Content-Head">NGHIỆP VỤ TIỀN MẶT</div>
        <div class="Content-Body">
          <div class="Wrapper">
            <div class="Receive">
              <div class="icon"></div>
              <div class="text">Thu tiền</div>
            </div>
          </div>
          <div class="Wrapper">
            <div class="First-Arrow">
              <div class="Line"><div class="X"></div></div>
            </div>
            <div class="Audit">
              <div class="icon"></div>
              <div class="text">Kiểm kê quỹ</div>
            </div>
            <div class="Second-Arrow">
              <div class="Line"><div class="X"></div></div>
            </div>
          </div>
          <div class="Wrapper">
            <div class="Payment">
              <div class="icon"></div>
              <div class="text">Chi tiền</div>
            </div>
          </div>
        </div>
        <div class="Content-Line"></div>
        <div class="Content-Bottom">
          <router-link to="/vendor" class="Vendor">
            <div class="icon"></div>
            <div class="text">Nhà cung cấp</div>
          </router-link>
          <router-link to="/account-system" class="Account-System">
            <div class="icon"></div>
            <div class="text">Hệ thống tài khoản</div>
          </router-link>
        </div>
      </div>
      <div class="MISAOverview-Content-Report">
        <div class="Content-Head">BÁO CÁO</div>
        <ul class="Content-Body">
          <li><span class="dot"></span> Bảng kê số dư tiền theo ngày</li>
          <li><span class="dot"></span> Sổ kế toán chi tiết quỹ tiền mặt</li>
          <li><span class="dot"></span> S03a2-DN: Sổ nhật ký chi tiền</li>
          <li><span class="dot"></span> S03a1-DN: Sổ nhật ký thu tiền</li>
        </ul>
        <div class="Content-Bottom">Tất cả báo cáo</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.MISAOverview {
  display: block !important;
  width: 100%;
  height: 100%;
  padding: 0 20px 20px 20px;
  background-color: #f4f5f8;
  .MISAOverview-Head {
    display: flex;
    width: 100%;
    height: 58px;
    border-bottom: 2px solid #d4d7dc;
    .Element {
      display: flex;
      align-items: flex-end;
      padding: 10px 20px;
      border-bottom: 4px solid transparent;
      cursor: pointer;
      a {
        color: #111;
      }
      &.active {
        border-bottom-color: #2ca01c;
        color: #111;
        font-weight: 700;
        font-size: 13px;
      }
      &:hover {
        a {
          color: #2ca01c;
        }
      }
    }
  }
  .MISAOverview-Content {
    display: flex;
    align-items: center;
    justify-content: center;
    height: calc(100% - 58px);
    .MISAOverview-Content-Business,
    .MISAOverview-Content-Report {
      height: 460px;
      background-color: #fff;
      border: 1px solid #e5e5e5;
      border-radius: 3px;
      .Content-Head {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 40px;
        border-bottom: 1px solid #e5e5e5;
        text-transform: uppercase;
        font-size: 14px;
        font-weight: 700;
      }
    }
    .MISAOverview-Content-Business {
      width: 690px;
      margin-right: 20px;
      .Content-Body {
        display: flex;
        flex-direction: column;
        justify-content: center;
        height: 340px;
        .Wrapper {
          padding-left: 100px;
          .Receive,
          .Payment,
          .Audit {
            width: 90px;
            height: 90px;
            cursor: pointer;
            .icon {
              width: 90px;
              height: 65px;
              background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
            }
            .text {
              text-align: center;
            }
            &:hover {
              box-shadow: 0 3px 6px rgb(0 0 0 / 16%);
            }
          }
          .Receive,
          .Payment {
            .icon {
              background-position: -245px -1495px;
            }
          }
          .Audit {
            .icon {
              background-position: -86px -1495px;
            }
          }
        }
        .Wrapper:nth-child(2) {
          display: flex;
          align-items: center;
          padding-left: 145px;
          .First-Arrow,
          .Second-Arrow {
            display: flex;
            align-items: center;
            height: 70%;
            .Line {
              position: relative;
              width: 100%;
              height: 2px;
              background-color: #b4c8b1;
              .X {
                position: absolute;
                top: 1px;
                right: 0;
                transform: translateY(-50%);
                border: 5px solid #fff;
                border-left: 5px solid #b4c8b1;
              }
            }
            &.First-Arrow {
              width: 180px;
              margin-right: 20px;
              border-left: 3px solid #b4c8b1;
            }
            &.Second-Arrow {
              width: 100px;
              margin-left: 20px;
            }
          }
        }
      }
      .Content-Line {
        height: 12px;
        background-color: #f4f5f8;
      }
      .Content-Bottom {
        display: flex;
        height: 68px;
        .Vendor,
        .Account-System {
          display: flex;
          flex-wrap: wrap;
          align-items: center;
          justify-content: center;
          width: 172px;
          padding: 7px;
          color: #111;
          cursor: pointer;
          .icon {
            width: 24px;
            height: 24px;
            background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
          }
          .text {
            flex-basis: 100%;
            text-align: center;
          }
          &.Vendor {
            border-right: 1px solid #e5e5e5;
            .icon {
              background-position: -928px -200px;
            }
          }
          &.Account-System .icon {
            background-position: -1376px -256px;
          }
          &:hover {
            box-shadow: 0 3px 6px rgb(0 0 0 / 16%);
          }
        }
      }
    }
    .MISAOverview-Content-Report {
      width: 300px;
      .Content-Body {
        height: 372px;
        padding: 0 16px;
        li {
          display: flex;
          align-items: center;
          height: 74px;
          padding: 16px 0;
          border-bottom: 1px solid #e5e5e5;
          &:hover {
            cursor: pointer;
            color: #0075c0;
          }
          .dot {
            display: inline-block;
            width: 6px;
            height: 6px;
            margin-right: 15px;
            border-radius: 50%;
            background-color: #646464;
          }
        }
      }
      .Content-Bottom {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 44px;
        border-top: 1px solid #e5e5e5;
        font-size: 13px;
        color: #0075c0;
        cursor: pointer;
      }
    }
  }
}
</style>
