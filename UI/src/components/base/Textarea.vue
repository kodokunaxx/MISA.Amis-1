<template>
  <div class="MISATextarea" :style="parentStyle">
    <label v-show="labelName != null"
      >{{ labelName }} <span v-show="isRequired">*</span></label
    >
    <textarea
      cols="30"
      rows="10"
      ref="input"
      style="resize: none;"
      :style="inputStyle"
      :placeholder="[[placeHolder]]"
      :value="value"
      :class="[className]"
      @blur="checkEmpty()"
    ></textarea>
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
    placeHolder: {
      type: String,
    },
    className: {
      type: String,
    },
    value: {
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
      };
    },
  },
  methods: {
    /**
     * Check rỗng
     * CreatedBy: nvcuong (28/05/2021)
     */
    checkEmpty() {
      const input = this.$refs.input;
      if (this.isRequired) {
        if (input.value.trim() == "") input.classList.add("error");
        else input.classList.remove("error");
      }
    },
  },
};
</script>

<style lang="scss">
.MISATextarea {
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
  textarea {
    display: block;
    width: 100%;
    height: 62px;
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
