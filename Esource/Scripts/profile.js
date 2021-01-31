$(function () {
    let bannerUpload = document.getElementById('ContentPlaceHolder1_upload_banner');
    let profileUpload = document.getElementById('ContentPlaceHolder1_upload_image');
    let bannerWrapper = $('#inputBorder');
    let profileWrapper = $('#inputImg');
    let bannerImg = $('#ContentPlaceHolder1_bannerePic');
    let profileImg = $('#ContentPlaceHolder1_profilePic')

    if (bannerWrapper) {
        bannerWrapper.on('click', function () {
            clickUpload($('#ContentPlaceHolder1_upload_banner'))
        });
    }

    if (profileWrapper) {
        profileWrapper.on('click', function () {
            clickUpload($('#ContentPlaceHolder1_upload_image'))
        });
    }

    if (bannerUpload) {
        bannerUpload.addEventListener('change', function () {
            preview(bannerUpload, bannerImg)
        });
    }

    if (profileUpload) {
        profileUpload.addEventListener('change', function () {
            preview(profileUpload, profileImg)
        });
    }
});

function clickUpload(fileUpload) {
    fileUpload.click();
}

function preview(input, img) {
    let file = input.files;
    let reader = new FileReader();
    reader.onload = function (e) {
        if (img) {
            img.attr('src', e.target.result);
        }
    }

    if (file && file[0]) {
        reader.readAsDataURL(file[0]);
    }
}
