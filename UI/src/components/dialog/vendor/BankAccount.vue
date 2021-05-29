<template>
  <div class="BankAccount">
    <div class="Thead">
      <div class="Row">
        <div class="Ele AccountNumber">SỐ TÀI KHOẢN</div>
        <div class="Ele BankName">TÊN NGÂN HÀNG</div>
        <div class="Ele Branch">CHI NHÁNH</div>
        <div class="Ele City">TỈNH/TP CỦA NGÂN HÀNG</div>
        <div class="Ele Icon"></div>
      </div>
    </div>
    <div class="Tbody">
      <div v-for="i in rows" :key="i" class="Row">
        <Input
          :w="'150px'"
          :field="'AccountNumber'"
          :class="['AccountNumber', 'Ele']"
        />
        <Input :w="'200px'" :field="'BankName'" :class="['BankName', 'Ele']" />
        <Input :w="'180px'" :field="'Branch'" :class="['Branch', 'Ele']" />
        <Input :w="'235px'" :field="'City'" :class="['City', 'Ele']" />
        <div class="Ele Icon">
          <span class="icon" @click="removeRow()"></span>
        </div>
      </div>
    </div>
    <div class="button">
      <button @click="addRow()">Thêm dòng</button>
      <button @click="removeAllRow()">Xóa hết dòng</button>
    </div>
  </div>
</template>

<script>
import Input from "../../base/Input";
export default {
  components: {
    Input,
  },
  data() {
    return {
      rows: 1,
    };
  },
  methods: {
    addRow() {
      this.rows++;
    },
    removeRow() {
      if (this.rows > 0) {
        this.rows--;
      }
    },
    removeAllRow() {
      this.rows = 0;
    },
  },
};
</script>

<style lang="scss">
.BankAccount {
  .Thead,
  .Tbody {
    .Row {
      display: flex;
      margin-bottom: 0 !important;
      .Ele {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 42px;
        padding: 5px 10px;
        background-color: #eceef1;
        border-left: 1px solid #c7c7c7;
        border-bottom: 2px solid #c7c7c7;
        // padding: 8px 0;
        text-align: center;
        font-weight: 700;
      }
      .AccountNumber {
        width: 150px;
      }
      .BankName {
        width: 200px;
      }
      .Branch {
        width: 180px;
      }
      .City {
        width: 235px;
      }
      .Icon {
        width: 40px;
      }
    }
  }
  .Tbody {
    .icon {
      display: block;
      width: 100%;
      height: 100%;
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat;
      background-position: -464px -306px;
      cursor: pointer;
    }
  }
  .button {
    button {
      padding: 2px 20px;
      margin-right: 10px;
      margin-top: 15px;
      border: 1px solid #333;
      border-radius: 2px;
      background-color: #fff;
      font-weight: 600;
      font-size: 12px;
      cursor: pointer;
    }
  }
}
</style>
