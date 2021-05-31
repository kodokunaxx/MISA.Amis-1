<template>
  <div class="MISASelection" :style="parentStyle">
    <label v-show="labelName != null"
      >{{ labelName }} <span v-show="isRequired">*</span></label
    >
    <div class="Wrapper">
      <input
        type="text"
        ref="input"
        :style="inputStyle"
        v-bind="$attrs"
        :class="[className]"
        :disabled="this.$store.getters.getIsReadOnly"
      />
      <div class="Icon-1" @click="toggleList()">
        <div class="icon" ref="arrow"></div>
      </div>
      <div class="Icon-2" v-show="numberOfIcons == 2">
        <div class="icon"></div>
      </div>
    </div>
    <ul class="Dropdown" v-if="isShowList && list">
      <li class="title" v-if="list.title.length">
        <span :title="list.title[0]">{{ list.title[0] }}</span>
        <span :title="list.title[1]">{{ list.title[1] }}</span>
      </li>
      <li
        v-for="(ele, index) in list.content"
        :key="index"
        @click="chooseOption(column == null ? ele.value : ele[column])"
      >
        <span class="key" v-if="ele.key" :title="ele.key">
          {{ ele.key }}
        </span>
        <span class="value" :title="ele.value" :style="spanStyle">
          {{ ele.value }}
        </span>

        <div class="icon">
          <div></div>
        </div>
      </li>
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
        paddingRight: this.numberOfIcons == 1 ? "32px" : "64px",
      };
    },
    spanStyle() {
      return {
        width: this.list.content[0].key ? "60%" : "100%",
      };
    },
  },
  updated() {
    this.$refs.input.value = this.valueBeforeUpdate;
  },
  data() {
    return {
      isShowList: false,
      valueBeforeUpdate: null,
    };
  },
  methods: {
    /**
     * Đóng, mở list
     * CreateBy: nvcuong (28/05/2021)
     */
    toggleList() {
      if (!this.$store.getters.getIsReadOnly) {
        this.isShowList = !this.isShowList;
      }
    },
    /**
     * Chọn dữ liệu
     * CreateBy: nvcuong (28/05/2021)
     */
    chooseOption(value) {
      this.valueBeforeUpdate = value;
      this.$refs.input.value = value; // Gán giá trị cho input
      this.closeList(); // Đóng list
    },
    closeList() {
      this.isShowList = false;
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
    right: 0;
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
      &:hover {
        background-color: #ebedf0;
        span {
          color: #3dc12b;
        }
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
      span {
        display: inline-block;
        white-space: nowrap;
        overflow: hidden;
        &:nth-child(1) {
          width: calc(40% - 10px);
          margin-right: 10px;
          //   text-transform: uppercase;
        }
        &:nth-child(2) {
          width: 60%;
        }
      }
      .icon.selected {
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
