<template>
  <div class="MISAAccount-System-Dialog">
    <div class="MISAAccount-System-Dialog-Content">
      <div class="Content-Head">
        <div class="Content-Head-Left">
          <div class="Title">Thêm tài khoản</div>
        </div>
        <div class="Content-Head-Right">
          <div class="Help"></div>
          <div class="Close"></div>
        </div>
      </div>
      <div class="Content-Body">
        <div class="Common">
          <div class="Row First-Row">
            <Input
              :isRequired="true"
              :labelName="'Số tài khoản'"
              :w="'calc(25% - 10px)'"
              :field="'AccountNumber'"
            />
          </div>
          <div class="Row Second-Row">
            <Input
              :isRequired="true"
              :labelName="'Tên tài khoản'"
              :w="'calc(50% - 5px)'"
              :field="'AccountName'"
            />
            <Input :labelName="'Tên tiếng Anh'" :w="'calc(50% - 5px)'" />
          </div>
          <div class="Row Third-Row">
            <Selection
              :labelName="'Tài khoản tổng hợp'"
              :w="'calc(25% - 10px)'"
            />
            <Selection
              :isRequired="true"
              :labelName="'Tính chất'"
              :w="'calc(25% - 10px)'"
            />
          </div>
          <div class="Row Fourth-Row">
            <Textarea :labelName="'Diễn giải'" :w="'100%'" :field="'Explain'" />
          </div>
          <div class="Row Fifth-Row">
            <input type="checkbox" field="IsKeepBusinessAccount" />
            <span>Có hạch toán ngoại tệ</span>
          </div>
        </div>
        <div class="Detail">
          <div class="Title">
            <div class="Icon"></div>
            <div class="Text">Theo dõi chi tiết theo</div>
          </div>
          <div class="Row First-Row">
            <div class="Row-Left">
              <div>
                <input type="checkbox" />
                <label title="Đối tượng tập hợp chi phí">Đối tượng</label>
              </div>
              <Selection :w="'50%'" :isDisable="true" :list="targetList" />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" /> <label>Tài khoản ngân hàng</label>
              </div>
            </div>
          </div>
          <div class="Row Second-Row">
            <div class="Row-Left">
              <div><input type="checkbox" /> <label>Đối tượng THCP</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
            <div class="Row-Right">
              <div><input type="checkbox" /> <label>Công trình</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
          </div>
          <div class="Row Third-Row">
            <div class="Row-Left">
              <div><input type="checkbox" /> <label>Đơn đặt hàng</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" /> <label>Hợp đồng bán hàng</label>
              </div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
          </div>
          <div class="Row Fourth-Row">
            <div class="Row-Left">
              <div><input type="checkbox" /> <label>Hợp đồng mua</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" />
                <label title="Khoản mục chi phí">Khoản mục CP</label>
              </div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
          </div>
          <div class="Row Fifth-Row">
            <div class="Row-Left">
              <div><input type="checkbox" /> <label>Đơn vị</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
            <div class="Row-Right">
              <div><input type="checkbox" /> <label>Mã thống kê</label></div>
              <Selection :w="'50%'" :isDisable="true" :list="list" />
            </div>
          </div>
        </div>
      </div>
      <div class="Content-Button">
        <div class="Cancel">
          <input class="btn btn-cancel" type="button" value="Hủy" />
        </div>
        <div class="Save">
          <input class="btn btn-save" type="button" value="Cất" />
          <input
            class="btn btn-save-and-add"
            type="button"
            value="Cất và thêm"
          />
        </div>
      </div>
      <div class="toggle">
        <div class="icon"></div>
      </div>
    </div>
  </div>
</template>

<script>
import Input from "../../base/Input";
import Textarea from "../../base/Textarea";
import Selection from "../../base/Selection";

export default {
  components: {
    Input,
    Textarea,
    Selection,
  },
  data() {
    return {
      targetList: {
        title: [],
        content: [["Nhà cung cấp"], ["Khách hàng"], ["Nhân viên"]],
      },
      list: {
        title: [],
        content: [["Chỉ cảnh báo"], ["Bắt buộc nhập"]],
      },
    };
  },
};
</script>

<style lang="scss">
:root {
  --w: 52%;
}

.MISAAccount-System-Dialog {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  display: flex;
  justify-content: flex-end;
  background-color: rgba($color: #000000, $alpha: 0.4);
  z-index: 1001;
  .MISAAccount-System-Dialog-Content {
    position: relative;
    width: var(--w);
    height: 100%;
    background-color: #fff;
    .Content-Head {
      display: flex;
      justify-content: space-between;
      width: 100%;
      height: 66px;
      .Content-Head-Left {
        display: flex;
        align-items: center;
        width: calc(100% - 78px);
        height: 100%;
        padding: 16px 14px 24px;
        .Title {
          font-size: 24px;
          font-weight: 600;
          color: #212121;
        }
      }
      .Content-Head-Right {
        display: flex;
        justify-content: center;
        width: 78px;
        padding: 12px;
        .Help,
        .Close {
          display: inline-block;
          width: 24px;
          height: 24px;
          margin: 0 2px;
          background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
          cursor: pointer;
          &.Help {
            background-position: -89px -144px;
          }
          &.Close {
            background-position: -144px -144px;
          }
        }
      }
    }
    .Content-Body {
      height: calc(100% - 134px);
      padding: 16px;
      overflow: auto;
      .Common {
        .Row {
          display: flex;
          flex-basis: 100%;
          margin-bottom: 10px;
        }
        .Second-Row {
          justify-content: space-between;
        }
        .Third-Row {
          display: flex;
          .MISASelection:first-child {
            margin-right: 10px;
          }
        }
        .Fifth-Row {
          input {
            margin-right: 15px;
            outline: none;
          }
        }
      }
      .Detail {
        .Title {
          display: flex;
          margin-top: 30px;
          margin-bottom: 20px;
          .Icon {
            width: 16px;
            height: 16px;
            margin-right: 10px;
          }
          .Text {
            color: #111;
            font-size: 16px;
          }
        }
        .Row {
          display: flex;
          margin-bottom: 10px;
          .Row-Left,
          .Row-Right {
            flex-basis: 50%;
            display: flex;
            align-items: center;
            padding-right: 60px;
            justify-content: space-between;
          }
          input {
            margin-right: 15px;
            outline: none;
          }
        }
      }
    }
    .Content-Button {
      display: flex;
      justify-content: space-between;
      align-items: flex-end;
      height: 68px;
      padding: 16px;
      border-top: 1px solid #cce4f9;
      .Cancel,
      .Save {
        .btn {
          height: 36px;
          padding: 8px 20px;
          border: 1px solid #8d9096;
          border-radius: 3px;
          background-color: #fff;
          outline: none;
          cursor: pointer;
          font-weight: 600;
          &:hover {
            background-color: #d2d3d6;
          }
        }
        &.Save {
          .btn-save-and-add {
            margin-left: 10px;
            border-color: #2ca01c;
            background-color: #2ca01c;
            color: #fff;
            &:hover {
              background-color: #35bf22;
            }
          }
        }
      }
    }

    .toggle {
      position: absolute;
      top: calc(50% - 25px);
      left: -6px;
      display: flex;
      align-items: center;
      width: 12px;
      height: 50px;
      border: 1px solid #d4d7dc;
      border-radius: 8px;
      background-color: #fff;
      cursor: pointer;
      .icon {
        width: 16px;
        height: 16px;
        background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -35px -360px;
      }
    }
  }
}
@media screen and (max-width: 1366px) {
  .MISAAccount-System-Dialog-Content {
    --w: 70%;
  }
}
/* width */
::-webkit-scrollbar {
  width: 10px;
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
</style>
