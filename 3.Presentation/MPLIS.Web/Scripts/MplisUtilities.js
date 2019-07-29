//hàm xử lý với tab dọc
function trigger_tab_doc() {
    $(".tab-doc").click(function (e) {
        if ($(e.target).parent().hasClass('tab-doc')) return;
        e.stopPropagation();
        if ($(this).find("a"))
            $(this).find("a").trigger("click");
        return false;
    });
}

//======= ngày tháng năm ======
//gán lại giá trị datatime từ dd/mm/yyyy to yyyy-mm-dd
function ConverDatatime(date) {
    var d = new Date(date.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yyyy = d.getFullYear();
    var formatted = yyyy + "-" + (mm < 10 ? "0" : "") + mm + "-" + (dd < 10 ? "0" : "") + dd;
    return formatted;
}

function ConverDatatimeddmmYYYY(date) {
    var d = new Date(date);
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yyyy = d.getFullYear();
    var formatted = (dd < 10 ? "0" : "") + dd + "/" + (mm < 10 ? "0" : "") + mm + "/" + yyyy;
    return formatted;
}

//============Cắt chuỗi lấy dãy số ===
function toMilliseconds(netDateString) {
    var reg = /\/Date\(([^)]+)\)\//;
    var mat = netDateString.match(reg);
    if (mat && mat.length > 1) {
        return +mat[1];
    }
    return NaN;
}

//=================== lấy ngày tháng năm ======
function formattedDate(d) {
    d = new Date(d);
    var month = String(d.getMonth() + 1);
    var day = String(d.getDate());
    const year = String(d.getFullYear());

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return day + '/' + month + '/' + year;
}

function printDate(dStr) {
    return formattedDate(toMilliseconds(dStr));
}

//===================Khởi tạo DataTable cho Phân Hệ Địa Chính - Xử Lý Hồ Sơ================
function InitDataTableXLHS(tableID) {
    return tableID.DataTable({
        "pageLength": 5,
        "lengthChange": false,
        "ordering": false,
        "info": false,
        "searching": false,
        "autoWidth": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Vietnamese.json"
        },
        "dom": 't<"bottom"p><"clear">'
    });
}

//===================Các hàm xử lý checkBox trên DataTable=============================
//Truyền vào table được InitDataTable và phần tử checkBoxAll của table
function ProcessCheckBox(table, checkBoxElement) {
    if (table.data().count() > 0) {
        //Bật trình lắng nghe sự kiện khi một trang của table được draw
        //Sự kiện được kích hoạt khi bấm vào Pre, PageNum, Next hoặc dùng page() để kích hoạt sự kiện
        table.on('draw', function (e, setting) {
            var table = $('#' + setting.sTableId).DataTable();
            //Kiểm tra xem thực hiện check hay uncheck checkBoxElement với page đang hiển thị
            ProcessCheckBoxAll(table, checkBoxElement);
            //Lắng nghe sự kiện check/uncheck checkbox từng row trên page đang hiển thị
            AddListCheckRow(table, checkBoxElement);
            //Lắng nghe sự kiện check/uncheck vào checkBoxAllID
            AddListCheckBoxAll(table, checkBoxElement)
        });
        //dùng page() để kích hoạt sự kiện 'draw' cho trang hiện tại đang hiển thị
        table.page(table.page.info().page).draw(false);
    } else {
        checkBoxElement.prop('disabled', true);
    }
}

//Thực hiện thay đổi giá trị của checkBoxElement thành check/uncheck
function ProcessCheckBoxAll(table, checkBoxElement) {
    //Ban đầu khởi tạo checked = true cho checkBoxElement;
    checkBoxElement.prop('checked', true);
    //Nếu tồn tại một row không được check thì set checked = false cho checkBoxElement;
    $.each($('tbody input', table.table().node()), function () {
        if (!$(this).is(':checked')) {
            checkBoxElement.prop('checked', false);
            //Thoát khỏi vòng lặp $.each bằng return false;
            return false;
        }
    });
}

function AddListCheckRow(table, checkBoxElement) {
    //Tắt trình lắng nghe sự kiện check/uncheck checkbox trên từng dòng
    $('tbody input', table.table().node()).off('change');
    //Bật lại trình lắng nghe sự kiện check/uncheck checkbox trên từng dòng
    $('tbody input', table.table().node()).on('change', function () {
        ProcessCheckBoxAll(table, checkBoxElement);
    });
}

function AddListCheckBoxAll(table, checkBoxElement) {
    //Tắt trình lắng nghe sự kiện check/uncheck trên checkBoxElement
    checkBoxElement.off('change');
    //Bật lại trình lắng nghe sự kiện check/uncheck trên checkBoxElement
    checkBoxElement.on('change', function () {
        ActionCheckAllRow(table, checkBoxElement);
    });
}

//Thực hiện check/uncheck tất cả các row trên trang đang hiển thị
function ActionCheckAllRow(table, checkBoxElement) {
    $.each($('tbody input', table.table().node()), function () {
        if (checkBoxElement.is(':checked')) {
            $(this).prop('checked', true);
        } else {
            $(this).prop('checked', false);
        }
    });
}

function GetDSCheck(table) {
    var checkBox = $('td:first input', table.rows().nodes());
    var dSCheck = [];
    $.each(checkBox, function () {
        if ($(this).is(':checked')) {
            dSCheck.push($(this).attr('value'));
        }
    });
    return dSCheck;
}

//===============

//===============Hàm xử lý addClass: activeRow cho DataTable=======
//Truyền vào table đã được InitDataTable, và classname để add
function ActiveRowDataTable(table, className) {
    //Duyệt qua tất cả các row trong table bật trình lắng nghe sự kiện click trên từng row
    $.each(table.rows().nodes(), function () {
        $(this).on('click', function () {
            console.log('click tr');
            var found = $(this).attr('class').indexOf(className);
            $.each(table.rows().nodes(), function () {
                $(this).removeClass(className);
            })
            if (found == -1) {
                $(this).addClass(className);
            }
        })
        $('button', this).on('click', function (event) {
            event.stopPropagation();
        })
    })
}

function OffActiveRowDataTable(table) {
    console.log('OffActiveRowDataTable');
    $.each(table.rows().nodes(), function () {
        console.log('tr');
        $(this).off('click');
    })
}

//=====================

function ActionBtnDelClick(table, callBack) {
    $.each(table.rows().nodes(), function () {
        var curRowData = table.row(this).data();
        $('.btnDel', this).on('click', function () {
            console.log('Click BtnDel!');
            callBack(table, curRowData);
        })
    })
}

function OffActionBtnDelClick(table) {
    $.each(table.rows().nodes(), function () {
        $('.btnDel', this).off('click');
    })
}

function ActionBtnSelClick(table, callBack) {
    $.each(table.rows().nodes(), function () {
        var curRowData = table.row(this).data();
        $('.btnSel', this).on('click', function () {
            console.log('Click BtnSel!');
            callBack(curRowData);
        })
    })
}

//===================Hàm removeRow cho DataTable==============
//Truyền vào TableID, và data-id của thẻ tr (<tr data-id="rowID" ...></tr>)
function RemoveRowDataTable(tableID, rowID) {
    table = tableID.DataTable();
    //==Duyệt qua tất cả các row của DataTable tìm đến row có data-id == rowID để thực hiện xóa
    $.each(table.rows().nodes(), function () {
        if ($(this).data('id') == rowID) {
            //==Get trang hiện tại và số trang trước khi thực hiện removeRow
            var pageCur = table.page.info().page;
            var pagesCur = table.page.info().pages;
            //==Thực hiện removeRow
            table.row($(this))
				.remove()
				.draw();
            //==Thực hiện update lại cột STT cho Table sau khi removeRow:
            //Cột STT là cột đầu tiên
            var stt = 1;
            $.each($('td:nth-child(1)', table.rows().nodes()), function () {
                $(this).text(stt + ".");
                stt++;
            });
            //==Thực hiện show page sau khi removeRow:
            //Get số trang sau khi thực hiện removeRow
            var pagesNew = table.page.info().pages;
            //Thực hiện show page sau khi xóa
            if (pageCur == 0 || (pageCur != (pagesCur - 1))) {
                //Page đầu hoặc page giữa show page chứa row đã bị xóa
                table.page(pageCur).draw(false);
            } else {
                //Page cuối xét điều kiện để show page trước page hiện tại hay show page hiện tại
                //Show page hiện tại khi pagesNew == pagesCur (page cuối vẫn còn row)
                //Show page trước page hiện tại khi pagesNew < pagesOld hoặc pagesNew != pagesOld (page cuối không còn row nào cả)
                //PS: Khi removeRow không xảy ra trường hợp pagesNew > pagesOld
                if (pagesNew == pagesCur) {
                    table.page(pageCur).draw(false);
                } else {
                    table.page(pageCur - 1).draw(false);
                }
            }
            return false;
        }
    });
}
//================================

function FormToObject(formID) {
    var objForm = {};
    var formArray = formID.serializeArray();
    for (var i = 0; i < formArray.length; i++) {
        objForm[formArray[i]['name']] = formArray[i]['value'];
    }
    return objForm;
}