
$(document).ready(function () {
    getCategorySwitch();
});

function getCategorySwitch() {

    const url = window.location.href;
    const productId = url.split("/").pop();

    console.log('Obtaining the category toggler...')
    $.ajax({
        url: '/Admin/Product/GetCategories',
        type: productId ? 'POST' : 'GET',
        data: { id: productId ? productId : null },
        success: function (result) {
            console.log('Obtained the category toggler.')
            $('#categoryToggler').html(result);
        },
        error: function () {
            console.log('Unable to obtain the category toggler.');
        }
    });
}
function toggleCategory(id) {
    console.log('Toggling category...')
    $.ajax({
        url: '/Admin/Product/ToggleCategory',
        type: 'GET',
        data: { id: id },
        success: function (result) {
            console.log('Toggle success.');
            $('#categoryToggler').html(result);
        },
        error: function () {
            console.log('Toggle failed.');
        }
    });
}
