$(document).ready(function () {

    $('#btnSearch').on('click', function () {

        var filterData = {

            searchObj: $('#txtFilter').val()
        };

        $.ajax({

            url: '/Kybers/Index',
            type: 'GET',
            data: filterData
        });
    });
});