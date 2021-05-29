<template>
  <div class="Contact">
    <div class="Content" v-if="this.$store.getters.getIsOrganization">
      <div class="Content-Left">
        <div class="Row First-Row">
          <Selection
            :w="'120px'"
            :labelName="'Người liên hệ'"
            :placeHolder="'Xưng hô'"
            :numberOfIcons="1"
            :list="this.$store.getters.getX"
          />
          <Input :w="'260px'" :placeHolder="'Họ và tên'" />
        </div>
        <div class="Row Second-Row">
          <Input :w="'100%'" :placeHolder="'Email'" />
        </div>
        <div class="Row Third-Row">
          <Input :w="'190px'" :placeHolder="'Số điện thoại'" />
        </div>
        <div class="Row Fourth-Row">
          <Input
            v-if="this.$store.getters.getIsCustomer"
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            :placeHolder="'Đại diện theo PL'"
          />
        </div>
      </div>
      <div class="Content-Right">
        <div class="Row First-Row" v-if="!this.$store.getters.getIsCustomer">
          <Input
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            :placeHolder="'Đại diện theo PL'"
          />
        </div>
        <div class="Row First-Row" v-if="this.$store.getters.getIsCustomer">
          <Input
            :w="'100%'"
            :labelName="'Người nhận hóa đơn điện tử'"
            :placeHolder="'Họ và tên'"
          />
        </div>
        <div class="Row Second-Row">
          <Input
            v-if="this.$store.getters.getIsCustomer"
            :w="'100%'"
            :placeHolder="'Email, ngăn cách nhiều email bởi dấu ;'"
          />
        </div>
        <div class="Row Third-Row">
          <Input
            v-if="this.$store.getters.getIsCustomer"
            :w="'190px'"
            :placeHolder="'Số điện thoại'"
          />
        </div>
      </div>
    </div>
    <div class="Content" v-if="!this.$store.getters.getIsOrganization">
      <div class="Content-Left">
        <div class="Row First">
          <Input
            :w="'100%'"
            :labelName="'Thông tin liên hệ'"
            :placeHolder="'Email'"
          />
        </div>
        <div class="Row Second">
          <Input :w="'50%'" :placeHolder="'Điện thoại di động'" />
        </div>
        <div class="Row Third">
          <Input :w="'50%'" :placeHolder="'Điện thoại cố định'" />
        </div>
        <div class="Row Fourth">
          <Input
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            :placeHolder="'Đại diện theo PL'"
          />
        </div>
      </div>
      <div class="Content-Right">
        <div class="Row First">
          <Input
            :w="'50%'"
            :placeHolder="'Số CMND/Thẻ căn cước'"
            :labelName="'Thông tin CMND/Thẻ căn cước'"
          />
        </div>
        <div class="Row Second">
          <!-- <Input :w="'50%'" :placeHolder="'Ngày cấp'" /> -->
          <div class="MISAInput Date">
            <input type="date" />
          </div>
        </div>
        <div class="Row First">
          <Input :w="'100%'" :placeHolder="'Nơi cấp'" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Input from "../../base/Input";
import Selection from "../../base/Selection";

export default {
  components: {
    Input,
    Selection,
  },
};
</script>

<style lang="scss">
.Content {
  display: flex;
  .Content-Left,
  .Content-Right {
    flex-basis: 50%;
    padding: 5px 26px 5px 0;
    .First-Row {
      display: flex;
      align-items: flex-end;
      justify-content: space-between;
    }
    .Row {
      margin-bottom: 10px;
    }
  }
}
.Date {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  width: 50%;
  input {
    display: block;
    width: 100%;
    height: 32px;
    padding: 6px 12px;
    margin-right: 4px;
    border: 1px solid #babec5;
    border-radius: 2px;
    color: #111;
    outline: none;
    &:focus {
      border-color: #2ca01c !important;
    }
    &.error {
      border-color: red;
    }
    &::placeholder {
      font-style: italic;
      font-size: 12px;
    }
  }
}
</style>
