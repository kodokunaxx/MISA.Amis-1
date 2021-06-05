<template>
  <div class="MISAVendor-Dialog">
    <div class="MISAVendor-Dialog-Content">
      <div class="Content-Head">
        <div class="Content-Head-Left">
          <div class="Title">Thông tin nhà cung cấp</div>
          <div class="Radio">
            <input
              type="radio"
              name="type"
              checked
              @click="setOrganization(true), rebind()"
            />
            Tổ chức
            <input
              type="radio"
              name="type"
              @click="setOrganization(false), rebind()"
            />
            Cá nhân
          </div>
          <div class="Customer">
            <input
              type="checkbox"
              @click="setCustomer(), rebind()"
              v-model="isCustomer"
              ref="customer"
              field="IsCustomer"
            />
            Là khách hàng
          </div>
        </div>
        <div class="Content-Head-Right">
          <div class="Help"></div>
          <div class="Close" @click="confirmClose()"></div>
        </div>
      </div>
      <div class="Content-Body">
        <Organziation v-if="this.$store.getters.getIsOrganization" />
        <Individual v-if="!this.$store.getters.getIsOrganization" />
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
            @click="addOrUpdate(getDataInForm(), 'save')"
            :disabled="this.$store.getters.getIsReadOnly"
          />
          <input
            class="btn btn-save-and-add"
            type="button"
            value="Cất và thêm"
            @click="addOrUpdate(getDataInForm(), 'save-and-add')"
            :disabled="this.$store.getters.getIsReadOnly"
          />
        </div>
      </div>
      <BaseLoading v-if="this.$store.getters.getIsLoading" />

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

      <Popup v-if="this.$store.getters.getIsShowConfirmClose">
        <template v-slot:Head>
          <div class="icon-popup icon-question"></div>
          <div class="text">
            Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
          </div>
        </template>
        <template v-slot:Button>
          <div class="wrapper">
            <div class="btn-cancel">
              <button class="btn" @click="closeConfirmClose()">Hủy</button>
            </div>
            <div class="btn-confirm">
              <button class="btn" @click="closeConfirmClose(), closeDialog()">
                Không
              </button>
              <button
                class="btn"
                @click="
                  closeConfirmClose(), addOrUpdate(getDataInForm(), 'save')
                "
              >
                Có
              </button>
            </div>
          </div>
        </template>
      </Popup>
    </div>
    <div class="Error-Duplicate" v-if="isDuplicate">
      <div class="icon-popup icon-warning"></div>
      <div class="text-popup">{{ errorDuplicateMsg }}</div>
    </div>
  </div>
</template>

<script>
import Organziation from "./Organization";
import Individual from "./Individual";
import BaseLoading from "../../base/BaseLoading";
import Popup from "../../base/Popup";
import axios from "axios";

export default {
  components: {
    Organziation,
    Individual,
    BaseLoading,
    Popup,
  },
  data() {
    return {
      isCustomer: this.$store.getters.getIsCustomer,
      isShowErrorPopup: false,
      emptyFieldName: null,
      errorDuplicateMsg: null,
      isDuplicate: false,
    };
  },
  updated() {
    this.isCustomer = this.$store.getters.getIsCustomer;
  },
  mounted() {
    this.focusFirstElement();

    // Bắt sự kiện shortcuts
    const dialog = document.querySelector(".MISAVendor-Dialog");
    let keysPressed = {};
    try {
      dialog.addEventListener("keydown", (event) => {
        if (keysPressed["Control"]) {
          if (event.key == "s" || event.key == "S") {
            event.preventDefault(); // hủy sự kiện mặc định
          }
        } else if (event.key == "Shift") {
          event.preventDefault();
          keysPressed["Shift"] = true;
        }

        keysPressed[event.key] = true;
        // Lưu
        if (keysPressed["Control"] && !keysPressed["Shift"]) {
          if (event.key == "s" || event.key == "S") {
            this.addOrUpdate(this.getDataInForm(), "save");
          }
        }

        // Lưu và thêm mới
        if (keysPressed["Control"] && keysPressed["Shift"]) {
          if (event.key == "s" || event.key == "S")
            this.addOrUpdate(this.getDataInForm(), "save-and-add");
        }
      });
      // xóa sự kiện keydown
      dialog.addEventListener("keyup", (event) => {
        delete keysPressed[event.key];
      });
    } catch (ex) {
      console.log(ex);
    }
  },
  watch: {
    isCustomer() {
      this.focusFirstElement();
    },
  },
  methods: {
    /**
     * Đóng dialog
     * CreatedBy: nvcuong (27/05/2021)
     */
    closeDialog() {
      this.$emit("closeDialog");
    },
    /**
     * Cài đặt là khách hàng
     * CreatedBy: nvcuong (27/05/2021)
     */
    setCustomer() {
      let isCustomer = this.$store.getters.getIsCustomer;

      this.$store.commit("setIsCustomer", !isCustomer);
      this.triggerAnimation();
    },

    /**
     * Hiện thông báo confirm trước khi đóng form
     * CreatedBy: nvcuong (31/05/2021)
     * */
    confirmClose() {
      this.$store.commit("setIsShowConfirmClose", true);
    },

    /**
     * Đóng thông báo confirm đóng form
     * CreatedBy: nvcuong (31/05/2021)
     * */
    closeConfirmClose() {
      this.$store.commit("setIsShowConfirmClose", false);
    },

    /**
     * Cài đặt là tổ chức
     * CreatedBy: nvcuong (27/05/2021)
     */
    async setOrganization(payload) {
      await this.$store.commit("setIsOrganization", payload);
      this.focusFirstElement();
    },

    /**
     * Kích hoạt animation
     * CreatedBy: nvcuong (27/05/2021)
     */
    triggerAnimation() {
      let customer = this.$refs.customer;
      let time = 500;
      let animationName = this.isCustomer ? "anticlockwise" : "clockwise";

      customer.style.animation = animationName + " " + time / 1000 + "s" + " 1";
      setTimeout(function() {
        customer.style.animation = "none";
      }, time);
    },
    /**
     * focus vào ô input đầu tiên
     * CreatedBy: nvcuong (28/05/2021)
     */
    focusFirstElement() {
      const path = ".MISAVendor-Dialog input[type='text']";
      const focusInput = document.querySelector(path);

      focusInput.focus();
    },
    /**
     * Lấy dữ liệu từ form
     * CreatedBy: nvcuong (28/05/2021)
     */
    getDataInForm() {
      try {
        const inputPath = ".MISAVendor-Dialog .MISAInput input";
        const textareaPath = ".MISAVendor-Dialog .MISATextarea textarea";
        const selectionPath = ".MISAVendor-Dialog .MISASelection input";
        const info = {};

        const inputs = document.querySelectorAll(inputPath);
        const textareas = document.querySelectorAll(textareaPath);
        const selections = document.querySelectorAll(selectionPath);
        const customerInput = this.$refs.customer;
        info["IsCustomer"] = customerInput.checked ? 1 : 0;
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
     * Xóa form khi chọn cất và thêm
     * CreatedBy: nvcuong (30/05/2021)
     */
    clearForm() {
      try {
        const inputPath = ".MISAVendor-Dialog .MISAInput input";
        const textareaPath = ".MISAVendor-Dialog .MISATextarea textarea";
        const selectionPath = ".MISAVendor-Dialog .MISASelection input";

        const inputs = document.querySelectorAll(inputPath);
        const textareas = document.querySelectorAll(textareaPath);
        const selections = document.querySelectorAll(selectionPath);
        const customerInput = this.$refs.customer;

        customerInput.checked = false;
        inputs.forEach((input) => (input.value = ""));
        textareas.forEach((textarea) => (textarea.value = ""));
        selections.forEach((input) => (input.value = ""));

        this.$store.dispatch("setNewVendorCode");
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Bind lại dữ liệu khi chọn loại là tổ chức, cá nhân hoặc chọn là khách hàng
     * CreatedBy: nvcuong (28/05/2021)
     */
    rebind() {
      if (this.$store.getters.getMODE == "ADD") return;
      const vm = this;
      setTimeout(function() {
        vm.$emit("rebind");
      }, 0);
    },

    /**
     * Thêm hoặc sửa thông tin NCC
     * CreatedBy: nvcuong (29/05/2021)
     */
    async addOrUpdate(vendor, type) {
      const vm = this;
      await this.checkValidate();

      const enableSubmit = this.$store.getters.getEnableSubmit;
      console.log("[MSG][From VendorDialog] Submittable:", enableSubmit);

      if (enableSubmit) {
        try {
          let url = this.$store.getters.getApiUrl + "/vendors";
          const method = this.$store.getters.getMODE === "ADD" ? "POST" : "PUT";

          if (method == "PUT") {
            // Sửa lại url nếu method là PUT
            const path = ".MISAVendor .Row.selected";
            const id = document.querySelector(path).attributes.id.value;

            url += `/${id}`;
          }

          // Config
          const config = {
            url: url,
            method: method,
            data: JSON.stringify(vendor),
            headers: {
              "Content-Type": "application/json",
            },
          };

          axios // Send request
            .request(config)
            .then(() => {
              if (type == "save") {
                vm.closeDialog(); // Đóng form khi thêm thành công
              } else {
                // debugger;
                vm.clearForm();
                vm.$store.commit("setMODE", "ADD"); // Sửa lại method thành POST
                vm.focusFirstElement();
                document
                  .querySelector('.MISAVendor-Dialog input[field="VendorName"]')
                  .classList.remove("error");
              }
              vm.$emit("reloadData"); // Load lại dữ liệu
            })
            .catch((error) => {
              console.log(
                "%c[ERROR][From VendorDialog]:",
                "color: red",
                error.response
              );
              if (error.response.data.ResultCode == 41) {
                // Set error
                vm.isDuplicate = true;
                vm.errorDuplicateMsg = `Mã NCC '${vendor.VendorCode}' đã tồn tại trên hệ thống.`;
                vm.focusFirstElement(); // focus
                document
                  .querySelector('.MISAVendor-Dialog input[field="VendorCode"]')
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
     * Check validte
     * CreatedBy: nvcuong (05/06/2021)
     */
    async checkValidate() {
      const vm = this;
      const requiredInputs = document.querySelectorAll(
        ".MISAVendor-Dialog input.Required"
      );
      let isValid = true;

      requiredInputs.forEach((requiredInput) => {
        if (!vm.checkEmpty(requiredInput)) {
          requiredInput.classList.add("error"); // Gán class error cho input
          vm.$store.commit("setEnableSubmit", false); // Disable submit
          isValid = false;
          vm.isShowErrorPopup = true; // Hiển thị popup thông báo lỗi

          let errorField = requiredInput.parentElement.children[0].innerHTML;
          vm.emptyFieldName = errorField.slice(0, errorField.length - 15); // Gán tên trường bị lỗi
        } else {
          requiredInput.classList.remove("error"); // Xóa class error cho input
        }
      });
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
      // const firstErrorField = document.querySelector('.MISAVendor-Dialog input.error');
      this.isShowErrorPopup = false; // đóng popup
      this.focusFirstElement();
    },
  },
};
</script>

<style lang="scss">
.MISAVendor-Dialog {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba($color: #000000, $alpha: 0.3);
  z-index: 1001;
  .MISAVendor-Dialog-Content {
    position: relative !important;
    width: 900px;
    height: 625px;
    background-color: #fff;
    overflow: hidden;
    .Content-Head {
      display: flex;
      height: 76px;
      .Content-Head-Left {
        display: flex;
        align-items: center;
        width: calc(100% - 78px);
        height: 100%;
        padding: 20px 12px 20px 32px;
        .Title {
          margin-right: 10px;
          font-size: 24px;
          color: #111;
          font-weight: 700;
        }
        .Radio {
          padding-top: 5px;
          input {
            margin: 0 10px;
            outline: none;
            cursor: pointer;
          }
        }
        .Customer {
          display: flex;
          align-items: center;
          padding-top: 5px;
          margin-left: 100px;
          input {
            display: inline-block;
            margin-right: 15px;
            width: 18px;
            height: 18px;
            transition: all 0.4s;
            outline: none;
          }
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
      height: calc(100% - 166px);
      padding: 0 32px 20px 32px;
      overflow: auto;
      .Detail-Info {
        padding: 5px 0 10px 0px;
        min-height: 300px;
        .List {
          display: flex;
          align-items: flex-end;
          height: 32px;
          margin-bottom: 10px;
          li {
            display: flex;
            align-items: center;
            height: 25px;
            padding: 0 10px;
            margin: 0 1px;
            border: 1px solid #c9ccd2;
            list-style: none;
            transition: color 0.3s;
            cursor: pointer;
            &:hover {
              color: #08bf1e;
            }
            &.active {
              height: 100%;
              background-color: #cce4f9;
              border: none;
            }
          }
        }
      }
      .Common-Info,
      .Detail-Info {
        .Row {
          margin-bottom: 10px;
        }
      }
    }
    .Content-Button {
      display: flex;
      justify-content: space-between;
      align-items: flex-end;
      height: 60px;
      padding: 0 32px;
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
}
.icon-popup {
  width: 48px;
  min-width: 48px;
  height: 48px;
  margin-right: 20px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
  cursor: pointer;
  // background-color: red;
}
.icon-warning {
  background-position: -24px -954px;
}
.icon-question {
  background-position: -826px -456px;
}
</style>
