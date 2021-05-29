<template>
  <div class="Address">
    <div class="Left">
      <div class="First-Row">
        <Selection
          :labelName="'Vị trí địa lí'"
          :w="'190px'"
          :value="'Việt Nam'"
          :numberOfIcons="1"
        />
        <Selection
          :w="'190px'"
          :placeHolder="'Tỉnh/Thành phố'"
          :numberOfIcons="1"
        />
      </div>
      <div class="Second-Row">
        <Selection
          :w="'190px'"
          :placeHolder="'Quận/Huyện'"
          :numberOfIcons="1"
        />
        <Selection :w="'190px'" :placeHolder="'Xã/Phường'" :numberOfIcons="1" />
      </div>
    </div>
    <div class="Right">
      <div class="First-Row">
        <div>Địa chỉ giao hàng</div>
        <div>
          <input type="checkbox" name="" id="" />
          Giống địa chỉ nhà cung cấp
        </div>
      </div>
      <div class="Second-Row">
        <button>Thêm dòng</button>
        <button>Xóa dòng</button>
      </div>
    </div>
  </div>
</template>

<script>
import Selection from "../../base/Selection";

export default {
  components: {
    Selection,
  },
};
</script>

<style lang="scss">
.Address {
  display: flex;
  .Left {
    flex-basis: 50%;
    .First-Row,
    .Second-Row {
      display: flex;
      align-items: flex-end;
      margin-bottom: 10px;
    }
  }
  .First-Row > div {
    margin-right: 10px;
  }
  .Second-Row > div {
    margin-right: 10px;
  }
  .Right {
    .First-Row,
    .Second-Row {
      display: flex;
      &.First-Row {
        padding-bottom: 5px;
        border-bottom: 2px solid #d3d6db;
        div:nth-child(1) {
          margin-right: 20px;
          font-weight: 700;
        }
        div:nth-child(2) {
          input {
            margin-right: 10px;
          }
        }
      }
      &.Second-Row {
        margin-top: 10px;
        button {
          padding: 2px 20px;
          margin-right: 10px;
          border: 1px solid #8d9096;
          border-radius: 3px;
          background-color: #fff;
          color: #111;
          // font-size: 12px;
          font-weight: 700;
          outline: none;
        }
      }
    }
  }
}
</style>
