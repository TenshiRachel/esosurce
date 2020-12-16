$(function () {
    let wrapper = document.getElementsByClassName('wrapper')[0];

    if (wrapper) {
        wrapper.addEventListener('click', clickUpload);
    }
});

function clickUpload() {
    let fileUpload = $('#ContentPlaceHolder1_upPoster');
    fileUpload.click();
}

//function Checkall() {
//    if ($('#check-all').is(':checked')) {
//        $('.files-check > input').attr('checked', 'true');
//    }
//    else {
//        $('.files-check > input').removeAttr('checked', 'false');
//    }
//}