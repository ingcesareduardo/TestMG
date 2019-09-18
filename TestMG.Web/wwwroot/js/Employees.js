$(document).ready(function () {
    $('#btnGetEmployees').click(function (e) {
        e.preventDefault();
        var self = $(this);
        let id = $("#Id").val();
        let url = 'Employee/EmployeesView/'+ id;
        $("#employeesContainer").load(url);
        
    });
});