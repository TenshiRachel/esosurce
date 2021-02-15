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

    counter = 0

    for (i = 1; i < 6; i++) {
        skillInput = document.getElementById("ContentPlaceHolder1_skill" + i)
        if (skillInput.value != "") {
            counter++;
        }
    }

    for (j = 5; j > counter; j--) {
        emptyInput = document.getElementById("skillInput" + j).style.display = "none"
    }

    if (counter == 0) {
        $('#removeButton').attr("disabled", true);
    }

    $("#addButton").click(function () {
        counter++;

        document.getElementById("skillInput" + counter).style.display = "block"
        disableOrEnable();
    });

    $("#removeButton").click(function () {
        skillInput = document.getElementById("ContentPlaceHolder1_skill" + counter).value = ""
        document.getElementById("skillInput" + counter).style.display = "none"
        counter--;
        disableOrEnable();
    });
});

function disableOrEnable() {
    if (counter == 0) {
        $('#removeButton').attr("disabled", true);
        return false;
    }
    else {
        $('#removeButton').attr("disabled", false);
    }
    if (counter >= 5) {
        $('#addButton').attr("disabled", true);
        return false;
    }
    else {
        $('#addButton').attr("disabled", false);
    }
}

function clickUpload(fileUpload) {
    fileUpload.click();
}

function preview(input, img) {
    let file = input.files;
    let reader = new FileReader();
    const validExt = /(\.jpg|\.jpeg|\.png)$/i;

    if (!validExt.exec(input.value)) {
        toastnotif('Invalid file type, only images are accepted', 'Error', 'error');
    }
    else {
        reader.onload = function (e) {
            if (img) {
                img.attr('src', e.target.result);
            }
        }

        if (file && file[0]) {
            reader.readAsDataURL(file[0]);
        }
    }
}
