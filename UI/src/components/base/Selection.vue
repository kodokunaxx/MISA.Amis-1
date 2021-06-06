<template>
  <div class="MISASelection" :style="parentStyle">
    <label v-show="labelName != null"
      >{{ labelName }} <span v-show="isRequired">*</span></label
    >
    <div class="Wrapper">
      <!------------------------------------------->
      <input
        type="text"
        ref="input"
        :style="inputStyle"
        v-bind="$attrs"
        :class="[className, isRequired ? 'Required' : '']"
        :disabled="this.$store.getters.getIsReadOnly || isDisable"
        @keyup="search($event.target.value)"
        @blur="isRequired ? checkEmpty() : null, closeList()"
      />
      <!------------------------------------------->
      <div
        class="Icon-1"
        @click="toggleList()"
        :class="[
          isDisable || this.$store.getters.getIsReadOnly ? '' : 'enable',
        ]"
      >
        <div class="icon" ref="arrow"></div>
      </div>
      <!------------------------------------------->
      <div class="Icon-2" v-show="numberOfIcons == 2">
        <div class="icon"></div>
      </div>
      <!------------------------------------------->
    </div>
    <ul class="Dropdown" v-if="isShowList && list" :style="dropdownStyle">
      <!------------------------------------------->
      <li class="title" v-if="search(keyword).title.length">
        <span
          v-for="(title, index) in search(keyword).title"
          :key="index"
          :title="title"
          class="column"
        >
          {{ title }}
        </span>
      </li>
      <!------------------------------------------->
      <li
        v-for="(ele, index) in search(keyword).content"
        :key="index"
        @click="chooseOption(ele[position], index, ele)"
        :class="[currentIndex == index ? 'selected' : '']"
      >
        <span v-for="(i, index) in ele" :key="index" :title="i" class="column">
          {{ i }}
        </span>
        <!--------------------------->
        <div class="icon">
          <div></div>
        </div>
        <!--------------------------->
      </li>
      <!------------------------------------------->
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    w: {
      type: String,
    },
    height: {
      type: String,
    },
    labelName: {
      type: String,
    },
    isRequired: {
      type: Boolean,
    },
    className: {
      type: String,
    },
    numberOfIcons: {
      type: Number,
    },
    list: {
      type: Object,
    },
    column: {
      type: String,
    },
    position: {
      type: Number,
      default: 0,
    },
    isDisable: {
      type: Boolean,
      default: false,
    },
    defaultIndex: {
      type: Number,
    },
  },
  computed: {
    parentStyle() {
      return {
        width: this.w,
      };
    },
    inputStyle() {
      return {
        height: this.height,
        paddingRight: this.numberOfIcons == 1 ? "32px" : "62px",
      };
    },
    dropdownStyle() {
      return {
        right:
          (this.list.content[0] && this.list.content[0].length) == 1 ? 0 : "",
      };
    },
  },
  mounted() {
    if (this.$store.getters.getIsReadOnly) {
      this.selfDisable = true;
    }
  },
  updated() {
    this.selfDisable = this.isDisable;
  },
  data() {
    return {
      isShowList: false,
      valueBeforeUpdate: null,
      tmp: this.list,
      keyword: "",
      currentIndex: 0,
      rotateDeg: 180,
      selfDisable: this.isDisable,
    };
  },
  methods: {
    /**
     * Đóng, mở list
     * CreateBy: nvcuong (28/05/2021)
     */
    toggleList() {
      if (!this.isDisable && !this.$store.getters.getIsReadOnly) {
        const icon = this.$refs.arrow;

        icon.style.transform = "rotate(" + this.rotateDeg + "deg)";
        this.rotateDeg = Number(this.rotateDeg) + 180;
        this.isShowList = !this.isShowList;
      }
    },
    /**
     * Check rỗng
     * CreatedBy: nvcuong (28/05/2021)
     */
    checkEmpty() {
      const input = this.$refs.input;
      if (!input) return;
      if (this.isRequired) {
        if (input.value.trim() == "") input.classList.add("error");
        else input.classList.remove("error");
      }
    },
    /**
     * Chọn dữ liệu
     * CreateBy: nvcuong (28/05/2021)
     */
    chooseOption(value, index, ele) {
      // this.valueBeforeUpdate = value;
      this.$refs.input.value = value; // Gán giá trị cho input
      this.currentIndex = index;
      this.$refs.input.classList.remove("error");
      this.closeList(); // Đóng list

      const icon = this.$refs.arrow;

      icon.style.transform = "rotate(" + this.rotateDeg + "deg)";
      this.rotateDeg = Number(this.rotateDeg) + 180;

      if (ele) {
        this.$emit("sendPayload", ele);
      }
    },
    closeList() {
      this.isShowList = false;
    },
    /**
     * Show dropdown
     * CreatedBy: nvcuong ( 31/05/2021)
     */
    openList() {
      this.isShowList = true;
    },
    /**
     * Tìm kiếm qua từ khóa được nhập
     * CreatedBy: nvcuong ( 31/05/2021)
     */
    search(keyword) {
      const vm = this;
      vm.keyword = keyword;
      const result = [];
      if (this.list) {
        result.title = this.list.title;
        result.content = [];

        this.list.content.forEach((element) => {
          for (let i = 0; i < element.length; i++) {
            if (
              element[i] &&
              element[i].toLowerCase().search(keyword.toLowerCase()) != -1
            ) {
              result.content.push(element);
              break;
            }
          }
        });
        this.openList();
      }

      return result;
    },
  },
};
</script>

<style lang="scss">
.MISASelection {
  position: relative;
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  label {
    display: block;
    height: 18px;
    color: #111;
    font-size: 12px;
    font-weight: 700;
    margin-bottom: 4px;
    span {
      margin-left: 2px;
      font-size: 10px;
      color: red;
    }
  }
  .Wrapper {
    position: relative;
    width: 100%;
    input {
      display: block;
      width: 100%;
      height: 32px;
      padding: 6px 64px 6px 12px;
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
      &.error:focus {
        border-color: red !important;
      }
      &::placeholder {
        font-style: italic;
        font-size: 12px;
      }
    }
    .Icon-1,
    .Icon-2 {
      position: absolute;
      top: 0;
      right: 0;
      display: flex;
      justify-content: center;
      align-items: center;
      width: 32px;
      height: 100%;
      cursor: pointer;
      &.Icon-1.enable:hover {
        background-color: #e0e0e0;
        border-color: #e0e0e0;
      }
      .icon {
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -560px -359px;
      }
      &.Icon-2 {
        right: 32px;
        border-right: 1px solid #babec5;
        .icon {
          background-position: -32px -312px;
        }
      }
    }
  }
  .Dropdown {
    position: absolute;
    top: 100%;
    left: 0;
    min-width: 100%;
    max-height: 200px;
    border: 1px solid #babec5;
    border-radius: 2px;
    background-color: #fff;
    box-shadow: 0 -8px 34px 0 rgb(0 0 0 / 5%);
    overflow-y: auto;
    overflow-x: hidden;
    z-index: 999;
    li {
      position: relative;
      height: 32px;
      padding: 5px 15px;
      cursor: pointer;
      white-space: nowrap;
      &:hover {
        background-color: #ebedf0;
        span {
          color: #3dc12b;
        }
      }
      .column {
        display: inline-block;
        width: 120px;
        margin-right: 20px;
        overflow: hidden;
      }
      &.title {
        margin-bottom: 3px;
        background-color: #f4f5f8;
        font-weight: 700;
        cursor: initial;
        span {
          font-size: 11px;
        }
        &:hover {
          span {
            color: #111;
            background-color: #f4f5f8;
          }
        }
      }
      &.selected {
        background-color: #2ca01c;
        color: #fff;
        .icon {
          visibility: visible;
        }
      }

      .icon {
        visibility: hidden;
        position: absolute;
        top: 0;
        right: 20px;
        bottom: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        width: 32px;
        div {
          width: 16px;
          height: 16px;
          background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
          background-position: -896px -312px;
        }
      }
    }
  }
}
</style>
