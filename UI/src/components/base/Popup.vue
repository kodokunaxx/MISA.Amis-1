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
    min-height: 184px;
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
      padding-bottom: 10px;
    }
    .Content-Button {
      display: flex;
      justify-content: space-between;
      align-items: flex-end;
      height: 60px;
      padding: 0 !important;
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
      .wrapper {
        display: flex;
        align-items: center;
        justify-content: space-between;
        width: 100%;
        height: 48px;
        margin-top: 20px;
        .btn {
          height: 36px;
          padding: 8px 20px;
          border: 1px solid #8d9096;
          border-radius: 3px;
          background-color: transparent;
          color: #111;
          cursor: pointer;
        }
        .btn-cancel {
          .btn:hover {
            background-color: #d2d3d6;
          }
          .btn {
            font-weight: 600;
          }
        }
        .btn-confirm {
          .btn:first-child {
            font-weight: 600;
            &:hover {
              background-color: #d2d3d6;
            }
          }
          .btn:last-child {
            margin-left: 10px;
            border-color: none;
            background-color: #2ca01c;
            color: #fff;
            &:hover {
              background-color: #35bf22;
            }
          }
        }
      }
    }
  }
  .icon-popup {
    width: 48px;
    min-width: 48px;
    height: 48px;
    margin-right: 20px;
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
    cursor: pointer;
    // background-color: red;
  }
  .icon-warning {
    background-position: -24px -954px;
  }
  .icon-question {
    background-position: -826px -456px;
  }
  .icon-dangerous {
    background-position: -592px -456px;
  }
}
</style>
