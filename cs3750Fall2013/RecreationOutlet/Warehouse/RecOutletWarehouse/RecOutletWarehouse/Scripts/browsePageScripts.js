$(function () {
    $('.ListitemDetails').click(function () {
        var href = this.href;
        $('#dialog').dialog({
            modal: true,
            height: 700,
            width:500,
            buttons: {
                Close: function () {
                    $(this).dialog("close");
                }
            },
            open: function (event, ui) {
                $(this).load(href, function (result) {
                    return false;
                });
            }
        });
        return false;
    });
});