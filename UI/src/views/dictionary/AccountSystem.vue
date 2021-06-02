<template>
  <div class="MISAAccount-System ">
    <div class="MISAAccount-System-Head flex items-center">
      <div class="MISAAccount-System-Head-ASList">
        <div class="title">Hệ thống tài khoản</div>
        <div class="back-to-all">
          <span class="icon"></span>
          <a href="#">
            Tất cả các danh mục
          </a>
        </div>
      </div>
      <div class="MISAAccount-System-Head-Button">
        <div class="btn btn-change-account">Chuyển tài khoản hoạch toán</div>
        <div class="btn btn-add">Thêm</div>
      </div>
    </div>
    <div class="Content-Feature">
      <div class="Feature-Left">
        <div class="Feature-Filter">
          <input
            type="text"
            class="Search-input"
            placeholder="Tìm kiếm theo số, tên tài khoản"
            ref="search"
          />
          <div class="icon"></div>
        </div>
      </div>
      <div class="Feature-Right">
        <div class="Shorten">Thu gọn</div>
        <div class="Icon Feature-Reload" title="Lấy lại dữ liệu"></div>
        <div class="Icon Feature-Export-Excel" title="Xuất ra Excel"></div>
      </div>
    </div>
    <div class="MISAAccount-System-Content">
      <div class="MISAAccount-System-Content-Table">
        <div class="Thead"></div>
        <div class="Tbody">
          <div class="Root">
            <Node :node="ele" v-for="(ele, index) in rows" :key="index" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Node from "../../components/account-system/Node";

export default {
  components: {
    Node,
  },
  data() {
    return {
      rows: [
        [
          {
            AccountNumber: 111,
            AccountName: "Tiền mặt",
            kind: "Dư nợ",
            EnglishName: "Cash in hand",
            Explain: "",
            Status: "Đang sử dụng",
          },
        ],
        [
          {
            AccountNumber: 112,
            AccountName: "Tiền mặt",
            kind: "Dư nợ",
            EnglishName: "Cash in hand",
            Explain: "",
            Status: "Đang sử dụng",
          },
        ],
        [
          {
            AccountNumber: 113,
            AccountName: "Tiền mặt",
            kind: "Dư nợ",
            EnglishName: "Cash in hand",
            Explain: "",
            Status: "Đang sử dụng",
          },
          [
            {
              AccountNumber: 1131,
              AccountName: "Tiền mặt",
              kind: "Dư nợ",
              EnglishName: "Cash in hand",
              Explain: "",
              Status: "Đang sử dụng",
            },
            [
              {
                AccountNumber: 11311,
                AccountName: "Tiền mặt",
                kind: "Dư nợ",
                EnglishName: "Cash in hand",
                Explain: "",
                Status: "Đang sử dụng",
              },
              {
                AccountNumber: 11312,
                AccountName: "Tiền mặt",
                kind: "Dư nợ",
                EnglishName: "Cash in hand",
                Explain: "",
                Status: "Đang sử dụng",
              },
            ],
          ],
        ],
      ],
    };
  },
};
</script>

<style lang="scss">
.MISAAccount-System {
  position: relative;
  overflow: scroll;
  flex-direction: column;
  height: calc(100vh - 50px);
  padding: 0px 30px 0px 20px;
}

.MISAAccount-System-Head {
  position: sticky;
  top: 0;
  left: 0;
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  height: 93px;
  padding: 22px 0 16px;
  background-color: #f4f5f6;
  z-index: 1001;
  .MISAAccount-System-Head-ASList {
    .title {
      font-size: 24px;
      font-weight: 700;
      color: #111;
    }
    .back-to-all {
      .icon {
        display: inline-block;
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -226px -357px;
        cursor: pointer;
      }
      a {
        color: #0075c0;
      }
    }
  }
}

.MISAAccount-System-Head-Button {
  display: flex;
  align-items: center;
  .btn {
    height: 36px;
    padding: 8px 20px;
    border-radius: 30px;
    cursor: pointer;
  }
  .btn-change-account {
    border: 1px solid #8d9096;
    background-color: transparent;
    color: #111;
    font-weight: 600;
    &:hover {
      background-color: #d2d3d6;
    }
  }
  .btn-add {
    border: 1px solid transparent;
    background-color: #2ca01c;
    color: #fff;
    margin-left: 10px;
    &:hover {
      background-color: #35bf22;
    }
  }
}

.Content-Feature {
  position: sticky;
  left: 0;
  display: flex;
  justify-content: space-between;
  height: 73px;
  padding: 16px 16px 10px 16px;
  background-color: #fff;
  .Feature-Left {
    display: flex;
    height: 100%;

    .Feature-Filter {
      position: relative;
      width: 250px;
      height: 32px;
      .Search-input {
        width: 100%;
        height: 100%;
        padding: 0 1.75rem 0 0.85rem;
        border: 1px solid #babec5;
        border-radius: 2px;
        outline: none;
        &:focus {
          border-color: #2ca01c;
        }
        &::placeholder {
          font-style: italic;
        }
      }
      .icon {
        position: absolute;
        top: 50%;
        right: 10px;
        transform: translateY(-50%);
        width: 16px;
        height: 16px;
        background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -992px -360px;
        cursor: pointer;
      }
    }
  }
  .Feature-Right {
    display: flex;
    align-items: center;
    .Icon {
      width: 24px;
      height: 24px;
      margin: 0 6px;
      background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
      cursor: pointer;
    }
    .Shorten {
      height: 24px;
      font-size: 13px;
      color: #0075c0;
      margin-top: 3px;
      margin-right: 12px;
      cursor: pointer;
    }
    .Feature-Reload {
      background-position: -423px -200px;
    }
    .Feature-Export-Excel {
      background-position: -704px -200px;
    }
  }
}

.MISAAccount-System-Content {
  //   background-color: red;
  z-index: 1000;

  .MISAAccount-System-Content-Table {
    .MISANode {
      position: relative;
      padding-left: 20px;
      .Row {
        display: flex;
        margin: 5px 0;
        padding: 5px 0;
        .Column {
          width: 200px;
        }
      }
      .Parent {
        position: absolute;
        top: 0;
        left: 0;
        width: 20px;
        height: 20px;
        background-color: red;
      }
    }
  }
}
</style>
