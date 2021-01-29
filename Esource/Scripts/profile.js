$(function () {
    let bannerUpload = document.getElementById('ContentPlaceHolder1_upload_banner');
    let profileUpload = document.getElementById('ContentPlaceHolder1_upload_image');
    let bannerWrapper = document.getElementById('inputBorder');
    let profileWrapper = document.getElementById('inputImg');
    let bannerImg = $('#ContentPlaceHolder1_bannerePic');
    let profileImg = $('#ContentPlaceHolder1_profilePic')

    if (bannerWrapper) {
        bannerWrapper.addEventListener('click', clickUpload(bannerUpload));
    }

    if (profileWrapper) {
        profileWrapper.addEventListener('click', clickUpload(profileUpload));
    }

    if (bannerUpload) {
        bannerUpload.addEventListener('change', preview(bannerUpload, bannerImg));
    }

    if (profileUpload) {
        profileUpload.addEventListener('change', preview(profileUpload, profileImg));
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
