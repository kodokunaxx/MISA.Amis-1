<template>
  <div class="BankAccount">
    <div class="thead">
      <div>SỐ TÀI KHOẢN</div>
      <div>TÊN NGÂN HÀNG</div>
      <div>CHI NHÁNH</div>
      <div>TỈNH/TP CỦA NGÂN HÀNG</div>
      <div></div>
    </div>
    <div class="tbody">
      <div><input type="text" /></div>
      <div><input type="text" /></div>
      <div><input type="text" /></div>
      <div><input type="text" /></div>
      <div><span class="icon"></span></div>
    </div>
    <div class="button">
      <button>Thêm dòng</button>
      <button>Xóa hết dòng</button>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.BankAccount {
  .thead,
  .tbody {
    display: flex;
    div {
      background-color: #eceef1;
      border-left: 1px solid #c7c7c7;
      border-bottom: 2px solid #c7c7c7;
      padding: 8px 0;
      text-align: center;
      font-weight: 700;
    }
    div:nth-child(1) {
      width: 150px;
    }
    div:nth-child(2) {
      width: 200px;
    }
    div:nth-child(3) {
      width: 180px;
    }
    div:nth-child(4) {
      width: 235px;
    }
    div:nth-child(5) {
      width: 40px;
    }
  }
  .tbody {
    div {
      display: flex;
      justify-content: center;
      align-items: center;
      height: 42px;
      padding: 5px 10px;
      .icon {
        display: block;
        width: 100%;
        height: 100%;
        background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
          no-repeat;
        background-position: -464px -306px;
      }
    }
    input {
      display: block;
      width: 100%;
      height: 100%;
      border: 1px solid transparent;
      padding: 5px 10px;
      border-radius: 3px;
      outline: none;
      &:focus {
        border-color: #2ca01c;
      }
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
    }
  }
}
</style>
