<template>
  <div class="Organziation">
    <div class="Common-Info">
      <div class="Common-Info-Left">
        <div class="Row First-Row">
          <Input
            :w="'140px'"
            :labelName="'Mã số thuế'"
            :class="'TaxCode'"
            :field="'TaxCode'"
          />
          <Input
            :w="'240px'"
            :labelName="'Mã nhà cung cấp'"
            :isRequired="true"
            :class="'VendorCode'"
            :refer="'autofocus'"
            :field="'VendorCode'"
          />
        </div>
        <div class="Row Second-Row">
          <Input
            :w="'100%'"
            :labelName="'Tên nhà cung cấp'"
            :isRequired="true"
            :class="'VendorName'"
            :field="'VendorName'"
          />
        </div>
        <div class="Row Third-Row">
          <Textarea
            :w="'100%'"
            :labelName="'Địa chỉ'"
            placeholder="VD: Số 82 Duy Tân, Dịch Vọng Hậu, Cầu Giấy, Hà Nội"
            :h="'62px'"
            :class="'Address'"
            :field="'Address'"
          />
        </div>
      </div>
      <div class="Common-Info-Right">
        <div class="Row First-Row">
          <Input
            :w="'154px'"
            :labelName="'Điện thoại'"
            :class="'PhoneNumber'"
            :field="'PhoneNumber'"
          />
          <Input
            :w="'250px'"
            :labelName="'Website'"
            :class="'Website'"
            :field="'Website'"
          />
        </div>
        <div class="Row Second-Row">
          <Selection
            :w="'100%'"
            :labelName="'Nhóm nhà cung cấp'"
            :class="'VendorGroup'"
            :numberOfIcons="2"
            :list="this.$store.getters.getVendorGroup"
            :field="'VendorGroup'"
          />
        </div>
        <div class="Row Third-Row">
          <Selection
            :w="'100%'"
            :labelName="'Nhân viên mua hàng'"
            :class="'Employee'"
            :numberOfIcons="2"
            :list="this.$store.getters.getEmployee"
            :field="'Employee'"
          />
        </div>
      </div>
    </div>
    <div class="Detail-Info">
      <ul class="List">
        <li
          class="Element"
          @click="selectDetailForm(1)"
          :class="[index == 1 ? 'active' : '']"
        >
          Liên hệ
        </li>
        <li
          class="Element"
          @click="selectDetailForm(2)"
          :class="[index == 2 ? 'active' : '']"
        >
          Điều khoản thanh toán
        </li>
        <li
          class="Element"
          @click="selectDetailForm(3)"
          :class="[index == 3 ? 'active' : '']"
        >
          Tài khoản ngân hàng
        </li>
        <li
          class="Element"
          @click="selectDetailForm(4)"
          :class="[index == 4 ? 'active' : '']"
        >
          Địa chỉ khác
        </li>
        <li
          class="Element"
          @click="selectDetailForm(5)"
          :class="[index == 5 ? 'active' : '']"
        >
          Ghi chú
        </li>
      </ul>
      <Contact v-show="index == 1" />
      <Rule v-show="index == 2" />
      <BankAccount v-show="index == 3" />
      <Address v-show="index == 4" />
      <Note v-show="index == 5" />
    </div>
  </div>
</template>

<script>
import Input from "../../base/Input";
import Textarea from "../../base/Textarea";
import Selection from "../../base/Selection";
import Contact from "./Contact";
import Rule from "./Rule";
import BankAccount from "./BankAccount";
import Address from "./Address";
import Note from "./Note";

export default {
  components: {
    Input,
    Textarea,
    Selection,
    Contact,
    Rule,
    BankAccount,
    Address,
    Note,
  },
  data() {
    return {
      index: 1,
    };
  },
  methods: {
    /**
     * Chọn form chi tiết
     * CreatedBy: nvcuong (28/05/2021)
     */
    selectDetailForm(index) {
      this.index = index;
    },
  },
};
</script>

<style lang="scss">
.Common-Info {
  display: flex;
  .Common-Info-Left,
  .Common-Info-Right {
    flex-basis: 50%;
    padding: 5px 26px 5px 0;
    &.Common-Info-Right {
      padding-right: 0;
    }
    .First-Row {
      display: flex;
      justify-content: space-between;
    }
  }
}
</style>
