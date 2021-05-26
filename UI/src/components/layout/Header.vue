<template>
  <div class="MISAHeader">
    <div class="MISAHeader-Left">
      <div class="MISAHeader-Left-Toggle"></div>
      <div class="MISAHeader-Left-Name" title="Công ty cổ phần MISA">
        <span class="name">CÔNG TY CỔ PHẦN MISA</span>
        <span class="icon"></span>
      </div>
      <div class="MISAHeader-Left-DC d-flex" title="DC-02">
        <span class="cirlce"></span>
        DC-02
      </div>
    </div>
    <div class="MISAHeader-Right">
      <div class="MISAHeader-Right-Search">
        <input
          type="text"
          class="Search-input"
          placeholder="Nhập từ khóa tìm kiếm"
        />
        <div class="Search-Trigger"></div>
      </div>
      <div class="MISAHeader-Right-Button">
        <div class="button d-flex" title="Tính năng mở rộng">
          <div class="icon threedots"></div>
        </div>
        <div class="button d-flex" title="Thiết lập">
          <div class="icon setting"></div>
        </div>
        <div class="button d-flex" title="Tư vấn sử dụng">
          <div class="icon message"></div>
        </div>
        <div class="button d-flex" title="Giúp">
          <div class="icon question"></div>
        </div>
        <div class="button d-flex" title="Thông báo">
          <div class="icon noti"></div>
        </div>
      </div>
      <div class="MISAHeader-Right-User">
        <div class="User-Avatar"></div>
        <div class="User-Name">
          <span class="name">
            Nguyễn Văn Cương
          </span>
          <div class="User-Name-Trigger"></div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.MISAHeader {
  position: absolute;
  display: flex;
  justify-content: space-between;
  align-items: center;
  top: 0;
  left: 178px;
  right: 0;
  bottom: 0;
  height: 48px;
  padding: 0 20px 0 12px;
  .MISAHeader-Left {
    display: flex;
    align-items: center;
    .MISAHeader-Left-Toggle {
      width: 24px;
      height: 24px;
      background: url('https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg') no-repeat;
      background-position: -846px -30px;
      cursor: pointer;
    }
    .MISAHeader-Left-Name {
      max-width: 450px;
      height: 20.8px;
      line-height: 20.8px;
      padding-left: 10px;
      cursor: pointer;
      .name {
        font-weight: 600;
        overflow: hidden;
        white-space: nowrap;
        text-overflow: ellipsis;
        font-size: 14px;
        color: #111;
      }
      .icon {
        display: inline-block;
        width: 14px;
        height: 14px;
        margin-left: 10px;
        background: url('https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg') no-repeat;
        background-position: -1130px -360px;
      }
    }
    .MISAHeader-Left-DC {
      width: 79px;
      height: 30px;
      margin: 0 15px;
      border: 1px solid #ebedf0;
      border-radius: 40px;
      font-size: 13px;
      cursor: pointer;
      .cirlce {
        display: inline-block;
        width: 7px;
        height: 7px;
        margin-right: 8px;
        border-radius: 50%;
        background-color: green;
      }
    }
  }
  .MISAHeader-Right {
    display: flex;
    align-items: center;
    .MISAHeader-Right-Search {
      position: relative;
      width: 200px;
      height: 32px;
      margin-right: 20px;
      .Search-input {
        display: inline-block;
        width: 100%;
        height: 32px;
        padding-left: 0.85em;
        padding-right: 24px;
        background: #fff;
        border-radius: 3px;
        color: #111;
        border: 1px solid #ebedf0;
        outline: none;
        &::placeholder {
          font-style: italic;
        }
      }
      .Search-Trigger {
        position: absolute;
        top: 50%;
        right: 8px;
        transform: translateY(-50%);
        width: 16px;
        height: 16px;
        background: url('https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg') no-repeat;
        background-position: -317px -148px;
        cursor: pointer;
      }
    }
    .MISAHeader-Right-Button {
      display: flex;
      align-items: center;
      height: 100%;
      margin-right: 10px;
      .button {
        width: 44px;
        height: 48px;
        padding: 0 10px;
        .icon {
          width: 24px;
          height: 24px;
          background: url('https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg') no-repeat;
          cursor: pointer;
          &.threedots {
            background-position: -568px -30px;
          }
          &.setting {
            background-position: -675px -30px;
          }
          &.message {
            background-position: -899px -30px;
          }
          &.question {
            background-position: -731px -30px;
          }
          &.noti {
            background-position: -788px -30px;
          }
        }
      }
    }
    .MISAHeader-Right-User {
      display: flex;
      align-items: center;
      padding: 0 16px;
      .User-Avatar {
        width: 32px;
        height: 32px;
        border: 1px solid #ebedf0;
        border-radius: 50%;
        cursor: pointer;
      }
      .User-Name {
        display: flex;
        cursor: pointer;
        .name {
          color: #111;
          font-size: 14px;
          font-weight: 600;
          margin: 0 10px;
        }
        .User-Name-Trigger {
          width: 16px;
          height: 16px;
          background: url('https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg') no-repeat;
          background-position: -1077px -30px;
        }
      }
    }
  }
}
</style>
