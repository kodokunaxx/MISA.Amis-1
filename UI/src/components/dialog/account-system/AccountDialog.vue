<template>
  <div
    class="MISAAccount-System-Dialog"
    v-if="this.$store.getters.getIsShowAccountDialog"
  >
    <div class="MISAAccount-System-Dialog-Content">
      <div class="Content-Head">
        <div class="Content-Head-Left">
          <div class="Title">Thêm tài khoản</div>
        </div>
        <div class="Content-Head-Right">
          <div class="Help"></div>
          <div class="Close" @click="closeDialog()"></div>
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
            <Input
              :labelName="'Tên tiếng Anh'"
              :w="'calc(50% - 5px)'"
              :field="'EnglishName'"
            />
          </div>
          <div class="Row Third-Row">
            <Selection
              :labelName="'Tài khoản tổng hợp'"
              :w="'calc(25% - 10px)'"
              :field="'ParentAccountNumber'"
            />
            <Selection
              :isRequired="true"
              :labelName="'Tính chất'"
              :w="'calc(25% - 10px)'"
              :list="kindList"
              :field="'Kind'"
            />
          </div>
          <div class="Row Fourth-Row">
            <Textarea :labelName="'Diễn giải'" :w="'100%'" :field="'Explain'" />
          </div>
          <div class="Row Fifth-Row">
            <input
              type="checkbox"
              field="IsKeepBusinessAccount"
              ref="IsKeepBusinessAccount"
            />
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
                <input type="checkbox" @click="toggleDisable(0)" />
                <label title="Đối tượng tập hợp chi phí">Đối tượng</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[0].value"
                :list="targetList"
                :field="'Target'"
              />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" /> <label>Tài khoản ngân hàng</label>
              </div>
            </div>
          </div>
          <div class="Row Second-Row">
            <div class="Row-Left">
              <div>
                <input type="checkbox" @click="toggleDisable(1)" />
                <label>Đối tượng THCP</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[1].value"
                :list="list"
                :field="'TargetTHCP'"
              />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" @click="toggleDisable(2)" />
                <label>Công trình</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[2].value"
                :list="list"
                :field="'Construction'"
              />
            </div>
          </div>
          <div class="Row Third-Row">
            <div class="Row-Left">
              <div>
                <input type="checkbox" @click="toggleDisable(3)" />
                <label>Đơn đặt hàng</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[3].value"
                :list="list"
                :field="'Order'"
              />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" @click="toggleDisable(4)" />
                <label>Hợp đồng bán hàng</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[4].value"
                :list="list"
                :field="'SellContract'"
              />
            </div>
          </div>
          <div class="Row Fourth-Row">
            <div class="Row-Left">
              <div>
                <input type="checkbox" @click="toggleDisable(5)" />
                <label>Hợp đồng mua</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[5].value"
                :list="list"
                :field="'PurchaseContract'"
              />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" @click="toggleDisable(6)" />
                <label title="Khoản mục chi phí">Khoản mục CP</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[6].value"
                :list="list"
                :field="'Items'"
              />
            </div>
          </div>
          <div class="Row Fifth-Row">
            <div class="Row-Left">
              <div>
                <input type="checkbox" @click="toggleDisable(7)" />
                <label>Đơn vị</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[7].value"
                :list="list"
                :field="'Unit'"
              />
            </div>
            <div class="Row-Right">
              <div>
                <input type="checkbox" @click="toggleDisable(8)" />
                <label>Mã thống kê</label>
              </div>
              <Selection
                :w="'50%'"
                :isDisable="disables[8].value"
                :list="list"
                :field="'StatisticalCode'"
              />
            </div>
          </div>
        </div>
      </div>
      <div class="Content-Button">
        <div class="Cancel">
          <input
            class="btn btn-cancel"
            type="button"
            value="Hủy"
            @click="closeDialog()"
          />
        </div>
        <div class="Save">
          <input
            class="btn btn-save"
            type="button"
            value="Cất"
            @click="
              addOrUpdate(
                getDataInForm(),
                getParentAccountNumber(),
                getId(),
                'save'
              )
            "
          />
          <input
            class="btn btn-save-and-add"
            type="button"
            value="Cất và thêm"
            @click="
              addOrUpdate(
                getDataInForm(),
                getParentAccountNumber(),
                getId(),
                'save-and-add'
              )
            "
          />
        </div>
      </div>
      <div class="toggle" @click="resize()">
        <div class="icon"></div>
      </div>
    </div>
    <div class="Error-Duplicate" v-if="isDuplicate">
      <div class="icon-popup icon-warning"></div>
      <div class="text-popup">{{ errorDuplicateMsg }}</div>
    </div>
    <Popup v-if="isShowErrorPopup">
      <template v-slot:Head>
        <div class="icon-popup icon-warning"></div>
        <div class="text">{{ emptyFieldName }} không được để trống</div>
      </template>
      <template v-slot:Button>
        <div class="btn-close">
          <button @click="closePopup()">Đóng</button>
        </div>
      </template>
    </Popup>
  </div>
</template>

<script>
import Input from "../../base/Input";
import Textarea from "../../base/Textarea";
import Selection from "../../base/Selection";
import Popup from "../../base/Popup";
import axios from "axios";

export default {
  components: {
    Input,
    Textarea,
    Selection,
    Popup,
  },
  mounted() {
    window.onresize = function() {
      const form = document.querySelector(".MISAAccount-System-Dialog-Content");
      if (!form) {
        return;
      }

      if (document.body.offsetWidth < 1366) {
        form.style.width = "75%";
      } else {
        form.style.width = "52%";
      }
    };
  },
  data() {
    return {
      API_URL: this.$store.getters.getApiUrl,
      targetList: {
        title: [],
        content: [["Nhà cung cấp"], ["Khách hàng"], ["Nhân viên"]],
      },
      list: {
        title: [],
        content: [["Chỉ cảnh báo"], ["Bắt buộc nhập"]],
      },
      kindList: {
        title: [],
        content: [["Dư nợ"], ["Dư có"], ["Lưỡng tính"], ["Không có số dư"]],
      },
      rotateDeg: "180",
      isShowErrorPopup: false,
      emptyFieldName: null,
      errorDuplicateMsg: null,
      isDuplicate: false,
      disables: [
        { value: true },
        { value: true },
        { value: true },
        { value: true },
        { value: true },
        { value: true },
        { value: true },
        { value: true },
        { value: true },
      ],
    };
  },
  methods: {
    resize() {
      const form = document.querySelector(".MISAAccount-System-Dialog-Content");
      const icon = document.querySelector(
        ".MISAAccount-System-Dialog-Content .toggle .icon"
      );
      const ratio = form.offsetWidth / document.body.offsetWidth;

      icon.style.transform = `rotate(${this.rotateDeg}deg)`;
      this.rotateDeg = Number(this.rotateDeg) + 180;
      if (ratio > 0.51 && ratio < 0.98) {
        form.style.width = "99%";
      } else {
        if (document.body.offsetWidth <= 1366) {
          form.style.width = "75%";
        } else {
          form.style.width = "52%";
        }
      }
    },

    toggleDisable(index) {
      this.disables[index].value = !this.disables[index].value;
      console.log(index, this.disables[index]);
    },

    /**
     * Đóng dialog
     * CreatedBy: nvcuong(03/06/2021)
     */
    closeDialog() {
      this.$store.commit("setIsShowAccountDialog", false); // Đóng dialog
      this.disables.forEach((disable) => (disable.value = true));
    },

    /**
     * Lấy dữ liệu từ form
     * CreatedBy: nvcuong (28/05/2021)
     */
    getDataInForm() {
      try {
        const inputPath = ".MISAAccount-System-Dialog .MISAInput input";
        const textareaPath =
          ".MISAAccount-System-Dialog .MISATextarea textarea";
        const selectionPath = ".MISAAccount-System-Dialog .MISASelection input";
        const isKeepBusinessAccount = this.$refs.IsKeepBusinessAccount;
        const info = {};

        const inputs = document.querySelectorAll(inputPath);
        const textareas = document.querySelectorAll(textareaPath);
        const selections = document.querySelectorAll(selectionPath);

        info.IsKeepBusinessAccount = isKeepBusinessAccount.checked ? 1 : 0;
        info.Status = "Đang sử dụng";
        inputs.forEach((input) => {
          const key = input.attributes.field.value;
          info[[key]] = input.value == "" ? null : input.value;
        });
        // debugger;
        textareas.forEach((textarea) => {
          const key = textarea.attributes.field.value;
          info[[key]] = textarea.value == "" ? null : textarea.value;
        });
        selections.forEach((input) => {
          const key = input.attributes.field.value;
          info[[key]] = input.value == "" ? null : input.value;
        });
        return info;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * focus vào ô input đầu tiên
     * CreatedBy: nvcuong (28/05/2021)
     */
    focusFirstElement() {
      const path = ".MISAAccount-System-Dialog input[type='text']";
      const focusInput = document.querySelector(path);

      focusInput.focus();
    },

    /**
     * Thêm hoặc sửa thông tin tài khoản
     * CreatedBy: nvcuong (03/06/2021)
     */
    async addOrUpdate(account, parent, id, type) {
      const vm = this;
      const MODE = this.$store.getters.getMODE;
      const method = MODE == "ADD" ? "POST" : "PUT";
      let endpoint = "";
      let API_URL = this.API_URL;

      this.checkValidate();
      const enableSubmit = this.$store.getters.getEnableSubmit;

      if (MODE == "ADD") {
        endpoint = "/accounts/ref" + (parent ? `?refer=${parent}` : "");
      } else if (MODE == "UPDATE") {
        endpoint = `/accounts/${id}`;
      }
      API_URL += endpoint;

      if (enableSubmit) {
        try {
          // Config
          const config = {
            url: API_URL,
            method: method,
            data: JSON.stringify(account),
            headers: {
              "Content-Type": "application/json",
            },
          };

          // Sửa lại url nếu người dùng nhập tài khoản tổng hợp sau
          if (account.ParentAccountNumber) {
            if (
              account.ParentAccountNumber.trim() != "" &&
              account.ParentAccountNumber.trim() != parent
            ) {
              API_URL += "?refer=" + account.ParentAccountNumber;
              config.url = API_URL;
            }
          }
          // to update

          axios // Send request
            .request(config)
            .then(() => {
              vm.$emit("reload"); // Load lại dữ liệu
              if (type == "save") {
                vm.closeDialog(); // Đóng form khi thêm thành công
              } else {
                vm.clearForm(); // clear form
                vm.$store.commit("setMODE", "ADD"); // sửa lại MODE là ADD
              }
            })
            .catch((error) => {
              console.log("[ERROR]:", error.response);
              if (error.response.data.ResultCode != 20) {
                // Set error
                vm.isDuplicate = true;
                if (error.response.data.ResultCode == 41) {
                  vm.errorDuplicateMsg = `Tài khoản '${account.AccountNumber}' đã tồn tại.`;
                } else if (error.response.data.ResultCode == 40) {
                  vm.errorDuplicateMsg =
                    "Dữ liệu <Tài khoản tổng hợp> không có trong danh mục.";
                }
                vm.focusFirstElement(); // focus
                document
                  .querySelector(
                    '.MISAAccount-System-Dialog input[field="AccountNumber"]'
                  )
                  .classList.add("error");
                // xóa error duplicate msg đi sau 4s hiển thị
                setTimeout(function() {
                  vm.isDuplicate = false;
                }, 4000);
              }
            });
        } catch (error) {
          console.log("%c[ERROR][From VendorDialog]:", "color: red", error);
        }
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

    /**
     * Check validate
     * nvcuong (28/05/2021)
     */
    checkValidate() {
      const vm = this;
      const requiredInputs = document.querySelectorAll(
        ".MISAAccount-System-Dialog input.Required"
      );
      let isValid = true;

      // Check empty
      requiredInputs.forEach((requiredInput) => {
        if (!vm.checkEmpty(requiredInput)) {
          requiredInput.classList.add("error"); // Gán class error cho input
          vm.$store.commit("setEnableSubmit", false); // Disable submit
          isValid = false;
          vm.isShowErrorPopup = true; // Hiển thị popup thông báo lỗi

          let lab = requiredInput.parentElement.children[0];
          if (lab.tagName == "INPUT") {
            lab = lab.parentElement.parentElement.children[0];
          }
          let errorField = lab.innerHTML;

          vm.emptyFieldName = errorField.slice(0, errorField.length - 15); // Gán tên trường bị lỗi
        } else {
          requiredInput.classList.remove("error"); // Xóa class error cho input
        }
      });
      // Check số tài khoản chứa số tài khoản cha ở đầu
      const child = document.querySelector(
        '.MISAAccount-System-Dialog input[field="AccountNumber"]'
      );
      const parent = document.querySelector(
        '.MISAAccount-System-Dialog input[field="ParentAccountNumber"]'
      );
      if (child && parent) {
        const foundIndex = child.value.indexOf(parent.value);
        if (foundIndex == -1 || foundIndex != 0) {
          vm.$store.commit("setEnableSubmit", false);
          isValid = false;
          vm.isDuplicate = true;
          vm.errorDuplicateMsg =
            "Số tài khoản không hợp lệ. Số tài khoản chi tiết phải bắt đầu bằng số của Tài khoản tổng hợp";
          // xóa error duplicate msg đi sau 4s hiển thị
          setTimeout(function() {
            vm.isDuplicate = false;
          }, 4000);
        }
      }

      if (isValid) {
        vm.$store.commit("setEnableSubmit", true); // Enable submit
      }
    },

    /**
     * Check rỗng
     * CreatedBy: nvcuong (28/05/2021)
     */
    checkEmpty(input) {
      if (input.value.trim() == "") return false;
      return true;
    },
    /**
     * Close popup
     * CreatedBy: nvcuong(29/05/2021)
     */
    closePopup() {
      this.isShowErrorPopup = false; // đóng popup
      this.focusFirstElement();
    },

    clearForm() {
      try {
        const inputPath = ".MISAAccount-System-Dialog .MISAInput input";
        const textareaPath =
          ".MISAAccount-System-Dialog .MISATextarea textarea";
        const selectionPath = ".MISAAccount-System-Dialog .MISASelection input";
        const isKeepBusinessAccount = this.$refs.IsKeepBusinessAccount;

        const inputs = document.querySelectorAll(inputPath);
        const textareas = document.querySelectorAll(textareaPath);
        const selections = document.querySelectorAll(selectionPath);

        isKeepBusinessAccount.checked = false;
        inputs.forEach((input) => (input.value = ""));
        textareas.forEach((textarea) => (textarea.value = ""));
        selections.forEach((input) => (input.value = ""));
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Get id
     * CreatedBy: nvcuong (03/06/2021)
     */
    getId() {
      const path = ".MISAAccount-System .Root .Row.selected .AccountId";
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
    width: 52%;
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
.Error-Duplicate {
  position: absolute;
  top: 10px;
  right: 10px;
  display: flex;
  align-items: center;
  min-width: 200px;
  padding: 10px 20px;
  border: 1px solid rgb(241, 57, 57);
  border-radius: 5px;
  background-color: #fff;
  z-index: 9999;
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
