thongbao = function () {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/ThongBao/ThongBaoo", // Gọi file PHP xử lý
        type: "GET",
        success: function (response) {
            UnBlockUI();
            $("#thongbao").html(response); // Chèn dữ liệu vào bảng
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}
function redirectToOrder(url) {
    window.location.href = url;
}
editStatusLH = function (id) {

    $.ajax({
        url: "/Admin/LienHe/Status",
        type: "POST",
        data: { id: id },
        success: function (res) {
            
        },
        error: function () {
            alert("Không thể thay đổi trạng thái!");
        }
    });
}

thongbao();
