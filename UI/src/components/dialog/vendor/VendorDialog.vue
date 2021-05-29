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
              @click="setOrganization(true)"
            />
            Tổ chức
            <input type="radio" name="type" @click="setOrganization(false)" />
            Cá nhân
          </div>
          <div class="Customer">
            <input
              type="checkbox"
              @click="setCustomer()"
              v-model="isCustomer"
              ref="customer"
            />
            Là khách hàng
          </div>
        </div>
        <div class="Content-Head-Right">
          <div class="Help"></div>
          <div class="Close" @click="closeDialog()"></div>
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
          <input class="btn btn-save" type="button" value="Cất" />
          <input
            class="btn btn-save-and-add"
            type="button"
            value="Cất và thêm"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Organziation from "./Organization";
import Individual from "./Individual";
export default {
  components: {
    Organziation,
    Individual,
  },
  data() {
    return {
      isCustomer: this.$store.getters.getIsCustomer,
    };
  },
  updated() {
    this.isCustomer = this.$store.getters.getIsCustomer;
  },
  mounted() {
    this.focusFirstElement();
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
  background-color: rgba($color: #000000, $alpha: 0.8);
  z-index: 1001;
  .MISAVendor-Dialog-Content {
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
          background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
            no-repeat;
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
}
</style>
