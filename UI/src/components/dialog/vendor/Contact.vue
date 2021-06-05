<template>
  <div class="Contact">
    <div class="Content" v-if="this.$store.getters.getIsOrganization">
      <div class="Content-Left">
        <div class="Row First-Row">
          <Selection
            :w="'120px'"
            :labelName="'Người liên hệ'"
            placeholder="Xưng hô"
            :numberOfIcons="1"
            :list="this.$store.getters.getX"
            :field="'ContactXungHo'"
          />
          <Input
            :w="'260px'"
            placeholder="Họ và tên"
            :field="'ContactFullName'"
          />
        </div>
        <div class="Row Second-Row">
          <Input :w="'100%'" placeholder="Email" :field="'ContactEmail'" />
        </div>
        <div class="Row Third-Row">
          <Input
            :w="'190px'"
            placeholder="Số điện thoại"
            :field="'ContactPhoneNumber'"
          />
        </div>
        <div class="Row Fourth-Row">
          <Input
            v-if="this.$store.getters.getIsCustomer"
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            placeholder="Đại diện theo PL"
            :field="'DDPL'"
          />
        </div>
      </div>
      <div class="Content-Right">
        <div class="Row First-Row" v-if="!this.$store.getters.getIsCustomer">
          <Input
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            placeholder="Đại diện theo PL"
            :field="'DDPL'"
          />
        </div>
        <div class="Row First-Row" v-if="this.$store.getters.getIsCustomer">
          <Input
            :w="'100%'"
            :labelName="'Người nhận hóa đơn điện tử'"
            placeholder="Họ và tên"
            :field="'RecipientFullName'"
          />
        </div>
        <div class="Row Second-Row" v-if="this.$store.getters.getIsCustomer">
          <Input
            :w="'100%'"
            placeholder="Email, ngăn cách nhiều email bởi dấu ;"
            :field="'RecipientEmail'"
          />
        </div>
        <div class="Row Third-Row" v-if="this.$store.getters.getIsCustomer">
          <Input
            :w="'190px'"
            placeholder="Số điện thoại"
            :field="'RecipientPhone'"
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
            placeholder="Email"
            :field="'ContactEmail'"
          />
        </div>
        <div class="Row Second">
          <Input
            :w="'50%'"
            placeholder="Điện thoại di động"
            :field="'ContactPhoneNumber'"
          />
        </div>
        <div class="Row Third">
          <Input
            :w="'50%'"
            placeholder="Điện thoại cố định"
            :field="'ContactTele'"
          />
        </div>
        <div class="Row Fourth">
          <Input
            :w="'100%'"
            :labelName="'Đại diện theo PL'"
            :field="'DDPL'"
            placeholder="Đại diện theo PL"
          />
        </div>
      </div>
      <div class="Content-Right">
        <div class="Row First">
          <Input
            :w="'50%'"
            placeholder="Số CMND/Thẻ căn cước"
            :labelName="'Thông tin CMND/Thẻ căn cước'"
            :field="'IdCard'"
          />
        </div>
        <div class="Row Second">
          <div class="MISAInput Date">
            <input type="date" :field="'IssuedOn'" />
          </div>
        </div>
        <div class="Row First">
          <Input :w="'100%'" placeholder="Nơi cấp" :field="'Place'" />
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
