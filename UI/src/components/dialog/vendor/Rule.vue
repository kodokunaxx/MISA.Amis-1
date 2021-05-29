<template>
  <div class="Rule">
    <div class="First">
      <Selection
        :labelName="'Điều khoản thanh toán'"
        :w="'188px'"
        :numberOfIcons="2"
        :field="'PaymentRuleName'"
        :list="this.$store.getters.getRule"
      />
      <Input :labelName="'Số ngày được nợ'" :w="'186px'" :field="'MaxDate'" />
      <Input :labelName="'Số nợ tối đa'" :w="'186px'" :field="'MaxDebt'"/>
    </div>
    <div class="Second">
      <Selection
        v-if="this.$store.getters.getIsCustomer"
        :labelName="'Tài khoản công nợ phải thu'"
        :w="'188px'"
        :value="'131'"
        :field="'ReceiveAccount'"
        :numberOfIcons="1"
        :list="this.$store.getters.getReceive"
      />
      <Selection
        :labelName="'Tài khoản công nợ phải trả'"
        :w="'188px'"
        :value="'331'"
        :numberOfIcons="1"
        :field="'PaymentAccount'"
        :list="this.$store.getters.getPayment"
      />
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
.Rule {
  .First,
  .Second {
    display: flex;
    margin-bottom: 10px;
  }
  .Second {
    .Dropdown {
      right: -100px !important;
    }
  }
}
.First > div:not(:first-child) {
  margin-left: 20px;
}
.Second > div:not(:first-child) {
  margin-left: 20px;
}
</style>
