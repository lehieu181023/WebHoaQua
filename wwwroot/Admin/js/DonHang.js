
loaddata = function () {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/DonHang/listdata", // Gọi file PHP xử lý
        type: "GET",
        success: function (response) {
            UnBlockUI();
            $("#listdata").html(response); // Chèn dữ liệu vào bảng
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

LoadModelAdd = function () {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/DonHang/Create", // Gọi file PHP xử lý
        type: "GET",
        success: function (response) {
            UnBlockUI();
            $("#target-div").html(response); // Chèn nội dung HTML vào div
            $("#myModal").modal("show"); // Hiện modal
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

LoadModelEdit = function (id) {
    debugger;
    BlockUI();
    $.ajax({
        url: "/Admin/DonHang/Edit", // Gọi file PHP xử lý
        type: "GET",
        data: { id: id },
        success: function (response) {
            UnBlockUI();
            if (response.success == false) {
                alert(response.message)
            }
            $("#target-div").html(response); // Chèn nội dung HTML vào div
            $("#myModal").modal("show"); // Hiện modal
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

successAction = function (res) {
    debugger;
    if (res.success) {
        UnBlockUI();
        $('#btnclosemodel').click();
        loaddata();
        alert(res.message);
    }
    else {
        UnBlockUI();
        alert(res.message);
    }
}

deleteData = function (id) {
    if (confirm("Bạn có chắc chắn muốn xóa không?")) {
        BlockUI(); // Không cho người dùng nhập liệu khi đang thao tác với dữ liệu
        $.ajax({
            url: "/Admin/DonHang/Delete",
            type: "POST",
            data: { id: id },
            success: function (res) {
                UnBlockUI();
                loaddata();
                if (res.success) {
                    alert(res.message);
                }
                else {
                    alert(res.message);
                }

            },
            error: function () {
                UnBlockUI();
                alert("Không thể xóa dữ liệu!");
            }
        });
    } else {
        console.log("Hủy xóa!");
    }
}

editData = function (id) {
    BlockUI(); // Không cho người dùng nhập liệu khi đang thao tác với dữ liệu
    $.ajax({
        url: "formsMember.php", // Gọi file PHP xử lý
        type: "POST",
        data: { id: id },
        success: function (response) {
            $("#target-div").html(response); // Chèn nội dung HTML vào div
            $("#myModal").modal("show"); // Hiện modal
            UnBlockUI();
        },
        error: function () {
            UnBlockUI();
            alert("Không thể tải dữ liệu!");
        }
    });
}

editStatus = function (id,status) {

    BlockUI(); // Không cho người dùng nhập liệu khi đang thao tác với dữ liệu
    $.ajax({
        url: "/Admin/DonHang/Status",
        type: "POST",
        data: { id: id, status: status },
        success: function (res) {
            UnBlockUI();
            loaddata();
            if (res.success) {
                alert(res.message);
            }
            else {
                alert(res.message);
            }
        },
        error: function () {
            UnBlockUI();
            alert("Không thể thay đổi trạng thái!");
        }
    });
}

loaddata();

