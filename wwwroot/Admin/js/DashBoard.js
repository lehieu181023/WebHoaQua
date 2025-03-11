
listdataRecentSales = function () {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/DashBoard/listdataRecentSales", // Gọi file PHP xử lý
        type: "GET",
        success: function (response) {
            UnBlockUI();
            $("#listdataRecentSales").html(response); // Chèn dữ liệu vào bảng
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

listdataTopSale = function () {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/DashBoard/listdataTopSale", // Gọi file PHP xử lý
        type: "GET",
        success: function (response) {
            UnBlockUI();
            $("#listdataTopSale").html(response); // Chèn dữ liệu vào bảng
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

listdataRecentSales();
listdataTopSale();

