$(function () {
    let wrapper = document.getElementsByClassName('wrapper')[0];
    let fileUpload = $('#ContentPlaceHolder1_upPoster');
    let remove = $('#fileRemove');

    if (wrapper) {
        wrapper.addEventListener('click', clickUpload);
    }

    if (fileUpload) {
        fileUpload.on('change', function () {
            previewFile(fileUpload);
        })
    }

    if (remove) {
        remove.on('click', function () {
            removeFile(fileUpload);
        })
    }
});

function clickUpload() {
    let fileUpload = $('#ContentPlaceHolder1_upPoster');
    fileUpload.click();
}

function previewFile(fileUpload) {
    let mask = $('#fileMask');
    let maskText = $('#maskText');
    let cardText = $('.card-text');
    let remove = $('#fileRemove');
    if (fileUpload.val() != "") {
        let fileName = fileUpload.val().split('\\');
        maskText.html(fileName[fileName.length - 1]);
        cardText.addClass('d-none');
        mask.removeClass('d-none');
        remove.removeClass('d-none');
    }
    else {
        mask.addClass('d-none');
        remove.addClass('d-none');
        cardText.removeClass('d-none');
    }
}

function removeFile(fileUpload) {
    let mask = $('#fileMask');
    let cardText = $('.card-text');
    let remove = $('#fileRemove');
    mask.addClass('d-none');
    remove.addClass('d-none');
    cardText.removeClass('d-none');
    fileUpload.val('');
}
