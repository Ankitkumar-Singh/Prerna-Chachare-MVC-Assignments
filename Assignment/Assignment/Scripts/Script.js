$(function () {
    $("#checkAll").click(function () {
        $("input[name='departmentIdsToDelete']").attr("checked", this.checked);

        $("input[name='departmentIdsToDelete']").click(function () {
            if ($("input[name='departmentIdsToDelete']").length == $("input[name='departmentIdsToDelete']:checked").length) {
                $("#checkAll").attr("checked", "checked");
            }
            else {
                $("#checkAll").removeAttr("checked");
            }
        });
    });
    $("#btnSubmit").click(function () {
        var count = $("input[name='employeeIdsToDelete']:checked").length;
        if (count == 0) {
            alert("No rows selected to delete");
            return false;
        }
        else {
            return confirm(count + " row(s) will be deleted");
        }
    });
});