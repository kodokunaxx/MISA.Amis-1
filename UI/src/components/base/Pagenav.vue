<template>
  <div class="MISAPagenav">
    <div class="Text">{{ items[index - 1].value }}</div>
    <div class="Icon" @click="toggleList()">
      <div class="icon-arrow" ref="arrow"></div>
    </div>
    <div class="Page-List" v-show="isShow">
      <div
        class="Page-Item"
        :class="[index == 1 ? 'active' : '']"
        @click="hideList(1, 10)"
      >
        {{ items[0].value }}
      </div>
      <div
        class="Page-Item"
        :class="[index == 2 ? 'active' : '']"
        @click="hideList(2, 20)"
      >
        {{ items[1].value }}
      </div>
      <div
        class="Page-Item"
        :class="[index == 3 ? 'active' : '']"
        @click="hideList(3, 30)"
      >
        {{ items[2].value }}
      </div>
      <div
        class="Page-Item"
        :class="[index == 4 ? 'active' : '']"
        @click="hideList(4, 50)"
      >
        {{ items[3].value }}
      </div>
      <div
        class="Page-Item"
        :class="[index == 5 ? 'active' : '']"
        @click="hideList(5, 100)"
      >
        {{ items[4].value }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [
        {
          index: 1,
          value: "10 bản ghi trên 1 trang",
        },
        {
          index: 2,
          value: "20 bản ghi trên 1 trang",
        },
        {
          index: 3,
          value: "30 bản ghi trên 1 trang",
        },
        {
          index: 4,
          value: "50 bản ghi trên 1 trang",
        },
        {
          index: 5,
          value: "100 bản ghi trên 1 trang",
        },
      ],
      isShow: false,
      index: 2,
      rotateDeg: 180,
    };
  },
  methods: {
    toggleList() {
      this.isShow = !this.isShow;

      const icon = this.$refs.arrow;
      icon.style.transform = "rotate(" + this.rotateDeg + "deg)";
      this.rotateDeg = Number(this.rotateDeg) + 180;
    },
    hideList(index, value) {
      this.isShow = false;
      this.index = index;
      this.$emit("setPageSize", value);
    },
  },
};
</script>

<style lang="scss">
.MISAPagenav {
  position: relative;
  display: flex;
  width: 200px;
  height: 32px;
  border: 1px solid #babec5;
  border-radius: 2px;
  background-color: #fff;
  .Text {
    width: 168px;
    height: 100%;
    padding: 6px 0 6px 12px;
  }
  .Icon {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 32px;
    height: 100%;
    cursor: pointer;
    .icon-arrow {
      width: 16px;
      height: 16px;
      background-image: url("../../assets/img/Sprites.64af8f61.svg");
      background-repeat: no-repeat;
      background-position: -560px -359px;
    }
    &:hover {
      background-color: #e0e0e0;
      border-color: #e0e0e0;
    }
  }
  .Page-List {
    position: absolute;
    top: -164px;
    left: 0;
    right: 0;
    border: 1px solid #babec5;
    border-radius: 2px;
    z-index: 1000;
    background-color: #fff;
    .Page-Item {
      display: flex;
      align-items: center;
      height: 32px;
      padding: 0 14px;
      cursor: pointer;
      &:hover {
        background-color: #ebedf0;
        color: #2ca01c;
      }
      &.active {
        color: #fff;
        background-color: #2ca01c;
      }
    }
  }
}
</style>
