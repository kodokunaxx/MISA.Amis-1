<template>
  <ul class="MISANode" :deepLevel="deepLevel">
    <!------------------------------------------------------------->
    <li class="Row">
      <div
        class="Column"
        v-for="(value, key) in node.parent"
        :key="key"
        :class="key"
        :style="parentStyle"
        v-show="columns.includes(key)"
        @click="selectRow($event.target.parentElement)"
      >
        {{ value }}
      </div>
      <div class="Column Feature">1</div>
    </li>

    <!------------------------------------------------------------->
    <li v-if="isShowDetail && node.children && node.children.length">
      <node
        v-for="(child, i) in node.children"
        :key="i"
        :node="child"
        :columns="columns"
        :deepLevel="parseInt(deepLevel) + 1"
      ></node>
    </li>
    <!------------------------------------------------------------->
    <div
      class="icon"
      v-if="node.children && node.children.length"
      @click="toggle()"
    ></div>
    <!------------------------------------------------------------->
  </ul>
</template>

<script>
export default {
  name: "node",
  props: ["node", "deepLevel", "columns"],
  computed: {
    parentStyle() {
      return {
        fontWeight: this.node.children && this.node.children.length ? 600 : 500,
      };
    },
  },
  data() {
    return {
      isShowDetail: false,
    };
  },
  methods: {
    /**
     * Đóng, hoặc mở node con
     * CreatedBy: nvcuong (02/06/2021)
     */
    toggle() {
      this.isShowDetail = !this.isShowDetail;
      this.refactorTable();
    },

    /**
     * Refactor lại table sau khi đóng, hoặc mở node con
     * CreatedBy: nvcuong (02/06/2021)
     */
    refactorTable() {
      setTimeout(function() {
        const nodes = document.querySelectorAll(".MISANode");
        let deepLevel = 1;
        nodes.forEach((node) => {
          const tmpDeepLevel = node.attributes.deepLevel;
          if (tmpDeepLevel && tmpDeepLevel.value > deepLevel) {
            deepLevel = tmpDeepLevel.value;
          }
        });

        const accNumColumns = document.querySelectorAll(
          ".MISANode .AccountNumber"
        );

        accNumColumns.forEach((accNumColumn) => {
          const deep =
            accNumColumn.parentElement.parentElement.attributes.deepLevel;
          if (deep) {
            accNumColumn.style.width =
              (deepLevel - deep.value) * 20 + 150 + "px";
          } else {
            accNumColumn.style.width = (deepLevel - 1) * 20 + 150 + "px";
          }
        });
      }, 0);
    },
    /**
     * Chọn row
     * CreatedBy: nvcuong (02/06/2021)
     */
    selectRow(target) {
      const path = ".MISAAccount-System .Root .MISANode .Row.selected";
      const selectedRows = document.querySelectorAll(path);

      selectedRows.forEach((selectedRow) =>
        selectedRow.classList.remove("selected")
      );
      target.classList.add("selected");
    },
  },
};
</script>

<style></style>
