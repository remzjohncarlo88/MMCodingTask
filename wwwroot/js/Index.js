
    var CreateUser = function () {
        $("#addModal").modal('show');
    }

    var ConfirmDelete = function (UserId) {
        $("#hiddenUserId").val(UserId);
        $("#deleteModal").modal('show');
    }

    var DeleteUser = function () {
        var Id = $("#hiddenUserId").val();
        $.ajax({
        type: "DELETE",
        url: '/Home/Delete',
        data: {"id": Id },
        success: function (result) {
        $("#deleteModal").modal("hide");
            }
        })
    }

    var DisplayDetails = function (userID) {
        $.ajax({
            type: "GET",
            url: '/Home/GetUser',
            data: { "userId": userID },
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                $("#detailsModal").find(".modal-body").html(response);
                $("#detailsModal").modal('show');
            }
        });
    }

    var CloseDeleteModal = function () {
        $("#deleteModal").modal("hide");
    }

    var CloseDisplayModal = function () {
        $("#detailsModal").modal("hide");
    }

    var CloseAddModal = function () {
        $("#addModal").modal("hide");
    }
