<template>
  <div class="MISAPopup">
    <div class="MISAPopup-Content">
      <div class="Content-Head">
        <slot name="Head"></slot>
      </div>
      <div class="Content-Button">
        <slot name="Button"></slot>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.MISAPopup {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba($color: #000000, $alpha: 0.4);
  z-index: 9999;
  .MISAPopup-Content {
    width: 444px;
    height: 184px;
    padding: 32px;
    border-radius: 3px;
    background-color: #fff;
    color: #111;
    box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
    overflow: hidden;
    .Content-Head {
      display: flex;
      align-items: center;
      border-bottom: 2px solid #b8bcc3;
    }
    .Content-Button {
      .btn-close {
        width: 100%;
        text-align: center;
        button {
          height: 36px;
          padding: 8px 20px;
          border: 1px solid transparent;
          color: #fff;
          background-color: #2ca01c;
          cursor: pointer;
        }
      }
    }
  }
}
</style>
