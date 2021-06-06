<template>
  <div class="MISARP-Dialog">
    <div class="MISARP-Dialog-Head">
      <div class="Head-Left">
        <div class="Icon"></div>
        <div class="Name">Phiếu chi {{ voucherNum }}</div>
        <div class="Option">
          <Selection
            :w="'350px'"
            :list="options"
            :field="'type'"
            :value="'5. Chi khác'"
          />
        </div>
      </div>
      <div class="Head-Right">
        <div class="Guide">
          <div class="Icon"></div>
          <div class="Text">Hướng dẫn</div>
        </div>
        <div class="Icon Setting"></div>
        <div class="Icon Question"></div>
        <div class="Icon Close" @click="closeDialog()"></div>
      </div>
    </div>
    <div class="MISARP-Dialog-Content">
      <div class="Content-Info">
        <div class="Content-Info-Left">
          <div class="Row First-Row">
            <Selection
              :labelName="'Đối tượng'"
              :numberOfIcons="2"
              :w="'40%'"
              :field="'VendorName'"
              :list="vendors"
              :position="1"
              @sendPayload="receivePayload($event)"
            />
            <Input
              :labelName="'Người nhận'"
              :w="'60%'"
              :field="'RecipientFullName'"
            />
          </div>
          <div class="Row Second-Row">
            <Input :labelName="'Địa chỉ'" :w="'100%'" :field="'Address'" />
          </div>
          <div class="Row Third-Row">
            <Input
              :labelName="'Lí do chi'"
              :w="'100%'"
              :field="'ReasonPayment'"
            />
          </div>
        </div>
        <div class="Content-Info-Right">
          <div class="Row First-Row">
            <div class="MISAInput KBADate">
              <label>Ngày hạch toán</label>
              <input
                type="date"
                :field="'KBADate'"
                :disabled="this.$store.getters.getIsReadOnly"
              />
            </div>
            <div class="Total-Money">
              <label>Tổng tiền</label>
              <div class="Value Money-Binding">
                {{ moneyValue | formatMoney }}
              </div>
            </div>
          </div>
          <div class="Row Second-Row">
            <div class="MISAInput VoucherDate">
              <label>Ngày phiếu chi</label>
              <input
                type="date"
                :field="'VoucherDate'"
                :disabled="this.$store.getters.getIsReadOnly"
              />
            </div>
          </div>
          <div class="Row Third-Row">
            <Input
              :w="'30%'"
              :labelName="'Số phiếu chi'"
              :field="'VoucherNumber'"
              :isRequired="true"
            />
          </div>
        </div>
        <div class="Content-Info-Bottom">
          <div class="Row First-Row">
            <Selection
              :w="'38%'"
              :numberOfIcons="2"
              :labelName="'Nhân viên'"
              :field="'Employee'"
              :list="employees"
              :position="1"
            />
            <div class="MISAInput Quantity">
              <label>Kèm theo</label>
              <div class="wrapper">
                <input
                  type="text"
                  :field="'Quantity'"
                  placeholder="Số lượng"
                  :disabled="this.$store.getters.getIsReadOnly"
                />
                chứng từ gốc
              </div>
            </div>
          </div>
          <div class="Row Second-Row">Tham chiếu <span>...</span></div>
        </div>
      </div>
      <div class="Content-Single">
        <div class="Row First-Row">
          <div class="KBA">
            <a href="#">Hạch toán</a>
          </div>
          <div class="Currency-Type">
            <span>Loại tiền</span>
            <Selection :w="'110px'" :field="'CurrencyType'" :value="'VND'"/>
          </div>
        </div>
        <div class="Row Second-Row">
          <table cellspacing="0" cellpadding="0">
            <thead>
              <th class="Empty"><div>#</div></th>
              <th class="Explain">DIỄN GIẢI</th>
              <th class="AccountNumber" title="Tài khoản nợ">TK NỢ</th>
              <th class="AccountNumber" title="tài khoản có">TK CÓ</th>
              <th class="Money">SỐ TIỀN</th>
              <th class="VendorCodeGrid">ĐỐI TƯỢNG</th>
              <th class="VendorNameGrid">TÊN ĐỐI TƯỢNG</th>
              <th class="BankAccountNumber">TK NGÂN HÀNG</th>
              <th class="Empty"></th>
            </thead>
            <tbody>
              <tr>
                <td class="Empty"><div>1</div></td>

                <td class="Explain">
                  <Input :w="'100%'" :field="'Explain'" />
                </td>

                <td class="AccountNumber">
                  <Selection
                    :w="'100%'"
                    :field="'AccountNumber'"
                    :list="accounts"
                    :isRequired="true"
                    @sendPayload="receivePayloadAccount($event)"
                  />
                </td>

                <td class="AccountNumber">
                  <Selection
                    :w="'100%'"
                    :field="'AccountNumber'"
                    :list="accounts"
                    @sendPayload="receivePayloadAccount($event)"
                  />
                </td>

                <td class="Money"><Input :w="'100%'" :field="'Money'" /></td>

                <td class="VendorCodeGrid">
                  <Selection
                    :w="'100%'"
                    :field="'VendorCodeGrid'"
                    :list="vendorsGrid"
                  />
                </td>

                <td class="VendorNameGrid">
                  <Input :w="'100%'" :field="'VendorNameGrid'" />
                </td>

                <td class="BankAccountNumber">
                  <Selection :w="'100%'" :field="'BankAccountNumber'" />
                </td>

                <td class="Empty"><div class="icon"></div></td>
              </tr>
              <tr class="Footer">
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td class="Money-Binding" style="font-weight: 600">
                  {{ moneyValue | formatMoney }}
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="Row Third-Row">
          <button :class="{ disable: this.$store.getters.getIsReadOnly }">
            Thêm dòng
          </button>
          <button :class="{ disable: this.$store.getters.getIsReadOnly }">
            Xóa hết dòng
          </button>
        </div>
        <div class="Row Fourth-Row">
          <div class="Title">
            <span class="icon"></span>
            <span style="font-weight: 600; margin-right: 10px">Đính kèm</span>
            <span style="color: #757575; font-size: 12px"
              >Dung lượng tối đa 5MB</span
            >
          </div>
          <div class="Upload">
            <input
              type="text"
              placeholder="Kéo/thả tệp vào đây hoặc bấm vào đây"
              :disabled="this.$store.getters.getIsReadOnly"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="MISARP-Dialog-Button">
      <div v-if="!addSuccess" class="Wait">
        <div class="Cancel">
          <button class="btn btn-cancel" @click="closeDialog()">Hủy</button>
        </div>
        <div class="Save">
          <button
            class="btn btn-save"
            title="Cất (Ctrl + S)"
            @click="addOrUpdate(getDataInForm())"
            :disabled="this.$store.getters.getIsReadOnly"
          >
            Cất
          </button>

          <div
            class="btn btn-save-and-print"
            title="Cất và In (Ctrl + Alt + P)"
            :disabled="this.$store.getters.getIsReadOnly"
          >
            Cất và In
            <div class="line"></div>
            <span class="icon add"></span>
          </div>
        </div>
      </div>
      <div v-if="addSuccess" class="Success">
        <div class="Success-Arrow">
          <button class="btn Prev"></button>
          <button class="btn Next"></button>
        </div>
        <div class="Success-Print">
          <div class="print">
            <div class="icon icon-print"></div>
            <div>In</div>
            <div class="icon icon-arrow"></div>
          </div>
          <div class="utility">
            <div class="icon"></div>
            <div>Tiện ích</div>
          </div>
        </div>
        <div class="Success-Cancel">
          <button class="btn">Bỏ ghi</button>
        </div>
      </div>
    </div>

    <Popup v-if="isShowErrorPopup">
      <template v-slot:Head>
        <div class="icon-popup icon-warning"></div>
        <div class="text">{{ emptyFieldName }} không được để trống</div>
      </template>
      <template v-slot:Button>
        <div class="btn-close">
          <button @click="closePopup()">Đóng</button>
        </div>
      </template>
    </Popup>

    <Popup v-if="isShowErrorDate">
      <template v-slot:Head>
        <div class="icon-popup icon-warning"></div>
        <div class="text">
          Ngày hạch toán phải lớn hơn hoặc bằng ngày chứng từ.
        </div>
      </template>
      <template v-slot:Button>
        <div class="btn-close">
          <button @click="closePopup()">Đóng</button>
        </div>
      </template>
    </Popup>

    <Popup v-if="isDuplicate">
      <template v-slot:Head>
        <div class="icon-popup icon-dangerous"></div>
        <div class="text">
          Số chứng từ {{ voucherNumberDuplicate }} đã tồn tại. Bạn có muốn
          chương trình tự động tăng số chứng từ không?
        </div>
      </template>
      <template v-slot:Button>
        <div class="btn-confirm">
          <button class="btn" @click="isDuplicate = false">
            Không
          </button>
          <button class="btn" @click="autoGenerateNewVoucherNumberAndAdd()">
            Có
          </button>
        </div>
      </template>
    </Popup>

    <Popup v-if="this.$store.getters.getIsShowConfirmClose">
      <template v-slot:Head>
        <div class="icon-popup icon-question"></div>
        <div class="text">
          Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
        </div>
      </template>
      <template v-slot:Button>
        <div class="wrapper">
          <div class="btn-cancel">
            <button class="btn" @click="closeConfirmClose()">Hủy</button>
          </div>
          <div class="btn-confirm">
            <button class="btn" @click="closeConfirmClose(), closeDialog()">
              Không
            </button>
            <button
              class="btn"
              @click="closeConfirmClose(), addOrUpdate(getDataInForm(), 'save')"
            >
              Có
            </button>
          </div>
        </div>
      </template>
    </Popup>
  </div>
</template>

<script>
import Selection from "../../base/Selection.vue";
import Input from "../../base/Input.vue";
import Popup from "../../base/Popup.vue";
import axios from "axios";

export default {
  components: {
    Selection,
    Input,
    Popup,
  },
  created() {
    const vm = this;
    const vendors = this.$store.getters.getVendors;
    const accounts = this.$store.getters.getAccounts;

    this.employees.title.push("Đơn vị");
    this.employees.title.push("ĐT di động");

    vendors.forEach((vendor) => {
      const row = [];
      const rowGrid = [];
      vm.vendors.columns.forEach((column) => {
        row.push(vendor[column]);
        if (column == "VendorCode" || column == "VendorName") {
          rowGrid.push(vendor[column]);
        }
      });
      vm.vendors.content.push(row);
      vm.vendorsGrid.content.push(rowGrid);
    });

    accounts.forEach((account) => {
      const row = [];
      vm.accounts.columns.forEach((column) => {
        row.push(account[column]);
      });
      vm.accounts.content.push(row);
    });
  },
  async mounted() {
    const vm = this;
    this.focusFirstElement();
    // ----------------------------------
    const reasonPayment = document.querySelector(
      '.MISARP-Dialog input[field="ReasonPayment"]'
    );
    const voucherNumber = document.querySelector(
      '.MISARP-Dialog input[field="VoucherNumber"]'
    );
    const dates = document.querySelectorAll(
      '.MISARP-Dialog input[type="date"]'
    );
    const money = document.querySelector('.MISARP-Dialog input[field="Money"]');
    const KBADate = dates[0];
    const VoucherDate = dates[1];

    reasonPayment.oninput = function() {
      if (!vm.stopBinding) {
        vm.handleBinding("master");
        vm.oldValue = reasonPayment.value;
      }
    };

    voucherNumber.onkeyup = function() {
      vm.voucherNum = voucherNumber.value;
    };

    money.oninput = function() {
      vm.moneyValue = money.value;
    };

    dates.forEach((date) => {
      date.valueAsDate = new Date();
    });

    vm.oldDate = KBADate.value;
    KBADate.onchange = function() {
      if (!vm.stopChangeDate) {
        if (VoucherDate.value != vm.oldDate) {
          vm.stopChangeDate = true;
        } else {
          VoucherDate.valueAsDate = new Date(KBADate.value);
          vm.oldDate = KBADate.value;
        }
      }
    };

    // ----------------------------------

    await this.getNewVoucherNumber(); // Lấy mã phiếu chi mới
    const voucherNumberField = document.querySelector(
      '.MISARP-Dialog input[field="VoucherNumber"]'
    );
    voucherNumberField.value = this.$store.getters.getNewVoucherNumber;
    this.voucherNum = this.$store.getters.getNewVoucherNumber;
  },
  data() {
    return {
      options: {
        title: [],
        content: [
          ["1. Trả tiền nhà cung cấp (không theo hóa đơn)"],
          ["2. Tạm ứng cho nhân viên"],
          ["3. Chi mua ngoài có hóa đơn"],
          ["4. Gửi tiền vào ngân hàng"],
          ["5. Chi khác"],
        ],
      },
      vendors: {
        columns: [
          "VendorCode",
          "VendorName",
          "TaxCode",
          "Address",
          "PhoneNumber",
        ],
        title: [
          "Đối tượng",
          "Tên đối tượng",
          "Mã số thuế",
          "Địa chỉ",
          "Điện thoại",
        ],
        content: [],
      },
      vendorsGrid: {
        columns: ["VendorCode", "VendorName"],
        title: ["Đối tượng", "Tên đối tượng"],
        content: [],
      },
      accounts: {
        columns: ["AccountNumber", "AccountName"],
        title: ["Số tài khoản", "Tên tài khoản"],
        content: [],
      },
      employees: this.$store.getters.getEmployee,
      oldValue: "",
      stopBinding: false,
      oldDate: null,
      stopChangeDate: false,
      isShowErrorPopup: false,
      isShowErrorDate: false,
      isDuplicate: false,
      voucherNumberDuplicate: null,
      voucherNum: null,
      moneyValue: "0,0",
      addSuccess: false,
    };
  },
  filters: {
    formatMoney(value) {
      if (!value) return "";

      const regex = /\B(?=(\d{3})+(?!\d))/g;
      return value.toString().replace(regex, ".");
    },
  },
  methods: {
    /**
     * Handle khi chọn đối tượng
     * CreatedBy: nvcuong (05/0/62021)
     */
    receivePayload(payload) {
      const vendorCodeGrid = document.querySelector(
        '.MISARP-Dialog input[field="VendorCodeGrid"]'
      );
      const address = document.querySelector(
        '.MISARP-Dialog input[field="Address"]'
      );
      const reasonPayment = document.querySelector(
        '.MISARP-Dialog input[field="ReasonPayment"]'
      );
      const vendorNameGrid = document.querySelector(
        '.MISARP-Dialog input[field="VendorNameGrid"]'
      );
      const explain = document.querySelector(
        '.MISARP-Dialog input[field="Explain"]'
      );

      vendorCodeGrid.value = payload[0];
      address.value = payload[3];
      reasonPayment.value = explain.value = this.oldValue =
        "Chi tiền cho " + payload[1];
      vendorNameGrid.value = payload[1];
      this.stopBinding = false;
    },

    receivePayloadAccount(payload) {
      const accountNumbers = document.querySelectorAll(
        '.MISARP-Dialog input[field="AccountNumber"]'
      );
      accountNumbers[0].value = accountNumbers[1].value = payload[0];
    },

    /**
     * Xử lý ràng buộc giữa master và grid
     * CreateBy: nvcuong(05/06/2021)
     */
    handleBinding(target) {
      const reasonPayment = document.querySelector(
        '.MISARP-Dialog input[field="ReasonPayment"]'
      );
      const explain = document.querySelector(
        '.MISARP-Dialog input[field="Explain"]'
      );

      if (target == "master") {
        if (this.oldValue != explain.value) {
          this.stopBinding = true;
          return;
        } else {
          explain.value = reasonPayment.value;
        }
      }
    },

    /**
     * Đóng dialog
     * CreatedBy: nvcuong (28/05/2021)
     */
    closeDialog() {
      this.$store.commit("setIsShowRPDialog", false);
      this.$store.commit("setIsReadOnly", false);
    },
    /**
     * Lấy dữ liệu từ form
     * CreatedBy: nvcuong (28/05/2021)
     */
    getDataInForm() {
      try {
        const inputPath = ".MISARP-Dialog .MISAInput input";
        const selectionPath = ".MISARP-Dialog .MISASelection input";
        const vendorCodeGridPath =
          ".MISARP-Dialog input[field='VendorCodeGrid']";
        const info = {};

        const inputs = document.querySelectorAll(inputPath);
        const selections = document.querySelectorAll(selectionPath);
        const vendorCodeGrid = document.querySelector(vendorCodeGridPath);

        inputs.forEach((input) => {
          const key = input.attributes.field.value;
          info[[key]] = input.value == "" ? null : input.value;
        });

        selections.forEach((input) => {
          const key = input.attributes.field.value;
          info[[key]] = input.value == "" ? null : input.value;
        });
        info["VendorCode"] = vendorCodeGrid.value;

        return info;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Check validte
     * CreatedBy: nvcuong (05/06/2021)
     */
    async checkValidate() {
      const vm = this;
      const requiredInputs = document.querySelectorAll(
        ".MISARP-Dialog input.Required"
      );
      const dates = document.querySelectorAll(
        '.MISARP-Dialog input[type="date"]'
      );
      const KBADate = dates[0];
      const VoucherDate = dates[1];

      let isValid = true;
      await vm.$store.commit("setEnableSubmit", false); // Enable submit

      requiredInputs.forEach((requiredInput) => {
        if (!vm.checkEmpty(requiredInput)) {
          requiredInput.classList.add("error"); // Gán class error cho input
          vm.$store.commit("setEnableSubmit", false); // Disable submit
          isValid = false;
          vm.isShowErrorPopup = true; // Hiển thị popup thông báo lỗi

          let errorField =
            requiredInput.parentElement.children[0].innerHTML || "Tài khoản nợ";
          vm.emptyFieldName = errorField.slice(0, errorField.length - 15); // Gán tên trường bị lỗi
        } else {
          requiredInput.classList.remove("error"); // Xóa class error cho input
        }
      });

      const KBA = new Date(KBADate.value).getDate();
      const Voucher = new Date(VoucherDate.value).getDate();
      if (KBA - Voucher < 0) {
        this.isShowErrorDate = true;
        isValid = false;
        console.log(isValid);
      }
      if (isValid) {
        vm.$store.commit("setEnableSubmit", true); // Enable submit
      }
    },

    /**
     * Check rỗng
     * CreatedBy: nvcuong (28/05/2021)
     */
    checkEmpty(input) {
      if (input.value.trim() == "") return false;
      return true;
    },

    /**
     * Hiện thông báo confirm trước khi đóng form
     * CreatedBy: nvcuong (31/05/2021)
     * */
    confirmClose() {
      this.$store.commit("setIsShowConfirmClose", true);
    },

    /**
     * Đóng thông báo confirm đóng form
     * CreatedBy: nvcuong (31/05/2021)
     * */
    closeConfirmClose() {
      this.$store.commit("setIsShowConfirmClose", false);
    },

    /**
     * Close popup
     * CreatedBy: nvcuong(29/05/2021)
     */
    closePopup() {
      // const firstErrorField = document.querySelector('.MISAVendor-Dialog input.error');
      this.isShowErrorPopup = false; // đóng popup
      this.isShowErrorDate = false;
      this.focusFirstElement();
    },

    /**
     * focus vào ô input đầu tiên
     * CreatedBy: nvcuong (28/05/2021)
     */
    focusFirstElement() {
      const path = ".MISARP-Dialog input[type='text']";
      const focusInput = document.querySelectorAll(path);

      focusInput[1].focus();
    },

    /**
     * Thêm hoặc sửa thông tin Phiếu thu, chi
     * CreatedBy: nvcuong (29/05/2021)
     */
    async addOrUpdate(voucher) {
      const vm = this;
      await this.checkValidate();

      const enableSubmit = this.$store.getters.getEnableSubmit;
      console.log("[MSG] Submittable:", enableSubmit);

      if (enableSubmit) {
        try {
          let url = this.$store.getters.getApiUrl + "/receiptpayments";
          const method = this.$store.getters.getMODE === "ADD" ? "POST" : "PUT";

          if (method == "PUT") {
            // Sửa lại url nếu method là PUT
            const path = ".MISARPL .Row.selected";
            const id = document.querySelector(path).attributes.id.value;

            url += `/${id}`;
          }

          // Config
          if (voucher) {
            voucher.Quantity = parseInt(voucher.Quantity);
          }
          const config = {
            url: url,
            method: method,
            data: JSON.stringify(voucher),
            headers: {
              "Content-Type": "application/json",
            },
          };

          axios // Send request
            .request(config)
            .then(() => {
              vm.$store.commit("setMODE", "ADD"); // Sửa lại method thành POST
              vm.$emit("reload"); // Load lại dữ liệu
              vm.$store.commit("setIsReadOnly", true);
              vm.addSuccess = true;
            })
            .catch((error) => {
              console.log("%c[ERROR]:", "color: red", error.response);
              if (error.response.data.ResultCode == 41) {
                // Set error
                vm.isDuplicate = true;
                vm.voucherNumberDuplicate = voucher.VoucherNumber;
                document
                  .querySelector('.MISARP-Dialog input[field="VoucherNumber"]')
                  .classList.add("error");
              }
            });
        } catch (error) {
          console.log("%c[ERROR]:", "color: red", error);
        }
      }
    },

    /**
     * Lấy số phiếu chi mới
     * CreatedBy: nvcuong (05/06/2021)
     */
    getNewVoucherNumber() {
      return this.$store.dispatch("setNewVoucherNumber");
    },

    /**
     * Tự động sinh mã mới và cất
     * CreatedBy: nvcuong (05/06/2021)
     */
    async autoGenerateNewVoucherNumberAndAdd() {
      await this.getNewVoucherNumber(); // Lấy mã phiếu chi mới
      const voucherNumberField = document.querySelector(
        '.MISARP-Dialog input[field="VoucherNumber"]'
      );
      voucherNumberField.value = this.$store.getters.getNewVoucherNumber;

      this.addOrUpdate(this.getDataInForm()); // Thêm dữ liệu
      this.isDuplicate = false; // Đóng popup lỗi duplicate
    },
  },
};
</script>

<style lang="scss">
.MISARP-Dialog {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #f4f5f8;
  z-index: 1001;
  overflow: auto;
  .MISARP-Dialog-Head {
    display: flex;
    justify-content: space-between;
    height: 54px;
    padding: 9px 16px;
    margin-bottom: 7px;
    .Head-Left {
      display: flex;
      align-items: center;
      .Icon {
        width: 24px;
        height: 24px;
        background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
        background-position: -648px -144px;
      }
      .Name {
        font-weight: 700;
        font-size: 24px;
        top: -7px;
        left: 20px;
        max-width: 300px;
        padding: 0 0 0 16px;
        color: #111;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
      }
      .Option {
        padding-left: 50px;
        .Dropdown {
          li {
            span {
              width: 290px;
            }
          }
        }
      }
    }
    .Head-Right {
      display: flex;
      align-items: center;
      .Icon {
        width: 24px;
        height: 24px;
        background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
        margin: 0 8px;
        &.Setting {
          background-position: -32px -144px;
        }
        &.Question {
          background-position: -89px -144px;
        }
        &.Close {
          background-position: -144px -144px;
          cursor: pointer;
        }
      }
      .Guide {
        display: flex;
        align-items: center;
        margin: 0 10px;
        .Icon {
          margin: 0 4px 0 0;
          background-position: -984px -144px;
        }
        .Text {
          color: #0075c0;
          font-size: 13px;
        }
      }
    }
  }
  .MISARP-Dialog-Content {
    height: calc(100% - 111px);
    overflow: auto;
    .Content-Info {
      display: flex;
      flex-wrap: wrap;
      padding: 4px 30px 24px 30px;
      .Content-Info-Left,
      .Content-Info-Right {
        .Row {
          display: flex;
          margin-bottom: 10px;
        }
        .Row:last-child {
          margin-bottom: 0;
          span {
            display: none;
          }
        }
      }
      .Content-Info-Left {
        flex-basis: 60%;
        padding-right: 10px;
        border-right: 1px solid #e0e0e0;
        .First-Row {
          height: 70px;
          .MISASelection {
            margin-right: 10px;
          }
        }
      }
      .Content-Info-Right {
        flex-basis: 40%;
        padding-left: 14px;
        .KBADate,
        .VoucherDate {
          width: 30%;
        }
        .First-Row {
          justify-content: space-between;
          height: 70px;
          .Total-Money {
            height: 100%;
            max-width: 250px;
            overflow-x: hidden;
            text-align: right;
            .Value {
              color: #111;
              font-size: 36px;
              font-weight: 600;
            }
          }
        }
      }
      .Content-Info-Bottom {
        flex-basis: 60%;
        .Row {
          display: flex;
          margin-top: 10px;
        }
        .First-Row {
          .Quantity {
            width: 25%;
            margin-left: 10px;
            .wrapper {
              display: flex;
              align-items: center;
              white-space: nowrap;
              input::placeholder {
                text-align: right;
              }
            }
          }
        }
        .Second-Row {
          span {
            margin-left: 10px;
            cursor: pointer;
            color: #0075c0;
            font-weight: 700;
          }
        }
      }
    }
    .Content-Single {
      padding: 14px 30px 24px 30px;
      background-color: #fff;

      .Row {
        display: flex;
        align-items: center;
      }
      .First-Row {
        justify-content: space-between;
        a {
          color: #0075c0;
          font-weight: 700;
          text-decoration: underline;
          &:hover {
            color: #2ca01c;
          }
        }
        .Currency-Type {
          display: flex;
          align-items: center;
          span {
            margin-right: 10px;
          }
        }
      }
      .Second-Row {
        margin-top: 20px;
        background-color: #f8f9fe;
        table {
          thead,
          tbody {
            .Explain {
              width: 250px;
            }
            .VendorNameGrid {
              width: 300px;
            }
            .AccountNumber {
              width: 125px;
            }
            .Money {
              width: 190px;
            }
            .Empty {
              width: 40px;
              div {
                width: 24px;
                margin: 0 auto;
                text-align: center;
              }
            }
          }
          thead {
            th {
              height: 33px;
              padding: 0 8px;
              border-left: 1px solid #c7c7c7;
              border-bottom: 2px solid #c7c7c7;
              background-color: #eceef1;
              text-align: left;
            }
          }
          tbody {
            tr {
              td {
                height: 40px;
                padding: 0 10px;
                border-bottom: 1.2px solid #c7c7c7;
                border-left: 1px dotted #c7c7c7;
                background-color: #fff;
                &.Money {
                  text-align: right;
                  input {
                    text-align: right;
                  }
                }
              }
              &.Footer {
                td {
                  height: 30px !important;
                  background-color: #f8f9fe !important;
                  border: none;
                }
                .Money-Binding {
                  padding-right: 15px;
                  text-align: right;
                }
              }
            }
            input {
              margin: 0;
            }
            .Empty {
              .icon {
                width: 16px;
                height: 16px;
                background: url("../../../assets/img/Sprites.64af8f61.svg")
                  no-repeat;
                background-position: -464px -312px;
                cursor: pointer;
              }
            }
          }
        }
      }
      .Third-Row {
        margin: 15px 0;
        button {
          height: 24px;
          padding: 2px 20px;
          margin-right: 10px;
          border: 1px solid #8d9096;
          border-radius: 2.5px;
          background-color: transparent;
          color: #111;
          font-weight: 600;
          &.disable {
            color: #afafaf;
          }
        }
      }
      .Fourth-Row {
        flex-wrap: wrap;
        .Title {
          display: flex;
          align-items: center;
          .icon {
            display: inline-block;
            width: 18px;
            height: 18px;
            margin-right: 8px;
            background: url("../../../assets/img/Sprites.64af8f61.svg")
              no-repeat;
            background-position: -539px -203px;
          }
        }
        .Upload {
          flex-basis: 100%;
          margin-top: 8px;
          input {
            width: 340px;
            height: 50px;
            outline: none;
            padding: 16px 20px;
            border: 1px solid #babec5;
            border-radius: 2px;
            &::placeholder {
              font-style: italic;
            }
          }
        }
      }
    }
  }
  .MISARP-Dialog-Button {
    .Wait,
    .Success {
      display: flex;
      align-items: center;
      justify-content: space-between;
      height: 50px;
      padding: 8px 16px;
      background-color: #38393d;
    }
    .Wait {
      .btn {
        height: 34px;
        padding: 6px 20px;
        margin-left: 8px;
        border: 1px solid #6b6c72;
        border-radius: 3px;
        background-color: transparent;
        color: #fff;
        cursor: pointer;
      }
      .Save {
        display: flex;
        .btn-save-and-print {
          display: flex;
          align-items: center;
          background-color: #35bf22;
          .line {
            width: 1px;
            height: 20px;
            background-color: #fff;
            margin: 0 10px 0 20px;
          }
          .icon {
            width: 16px;
            height: 16px;
            background: url("../../../assets/img/Sprites.64af8f61.svg")
              no-repeat;
            background-position: -848px -359px;
          }
        }
      }
    }
    .Success {
      .btn {
        height: 34px;
        padding: 6px 20px;
        border: 1px solid #6b6c72;
        border-radius: 3px;
        background-color: transparent;
        cursor: pointer;
      }
      .Success-Arrow {
        display: flex;
        justify-content: center;
        align-items: center;
        .Prev,
        .Next {
          background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
        }
        .Prev {
          background-position: -21px -400px;
        }
        .Next {
          margin-left: 8px;
          background-position: -68px -400px;
        }
      }
      .Success-Print {
        display: flex;
        align-items: center;
        .icon {
          background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat;
          margin: 0 8px;
        }
        .print {
          display: flex;
          align-items: center;
          padding-right: 15px;
          border-right: 1px solid #b8bcc3;
          color: #b8bcc3;
          .icon-print {
            width: 24px;
            height: 24px;
            background-position: -33px -200px;
          }
          .icon-arrow {
            width: 16px;
            height: 16px;
            margin-top: 4px;
            background-position: -847px -360px;
          }
        }
        .utility {
          display: flex;
          align-items: center;
          padding-left: 15px;
          color: #b8bcc3;
          .icon {
            width: 24px;
            height: 24px;
            background-position: -200px -199px;
          }
        }
      }
      .Success-Cancel {
        button {
          display: flex;
          align-items: center;
          background-color: #35bf22;
          height: 34px;
          padding: 6px 20px;
          color: #fff;
        }
      }
    }
  }
}

.MISAPopup {
  .btn-confirm {
    display: flex;
    justify-content: space-between;
    width: 100%;
    button {
      height: 36px;
      padding: 8px 20px;
      border: 1px solid #8d9096;
      border-radius: 3px;
      background-color: transparent;
      color: #111;
      cursor: pointer;
      &:first-child:hover {
        background-color: #d2d3d6;
      }
      &:last-child {
        color: #fff;
        background-color: #2ca01c;
        &:hover {
          background-color: #35bf22;
        }
      }
    }
  }
}
</style>
