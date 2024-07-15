
$(document).ready(function () {
    getCategorySwitch();
});

function getCategorySwitch() {

    const url = window.location.href;
    const productId = url.split("/").pop();

    $.ajax({
        url: '/Admin/Product/GetCategories',
        type: 'GET',
        data: { id: productId ? productId : null },
        success: function (result) {
            $('#categoryToggler').html(result);
        },
        error: function () {
        }
    });
}
function toggleCategory(id) {
    $.ajax({
        url: '/Admin/Product/ToggleCategory',
        type: 'POST',
        data: { id: id },
        success: function (result) {
            $('#categoryToggler').html(result);
        },
        error: function () {
        }
    });
}
