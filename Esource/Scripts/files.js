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

$(function () {
    let searchInput = $('input[name="search"]');
    let trs = $('tbody tr', '#files-table');

    let filterCheckboxes = $('.filter-all, .filter-name, .filter-size, .filter-type, .filter-shared, .filter-modified');
    let filters = ['name', 'size', 'type', 'shared', 'modified'];

    // Filters
    $('.search-filters').on('click', function () {
        return false;
    });

    filterCheckboxes.parent().on('click', function () {
        let checkbox = $(this).children('input[type="checkbox"]');

        if (checkbox.is(':checked')) {
            if (checkbox.hasClass('filter-all')) {
                $('.filter-all').prop('checked', false);
                $('.filter-name').prop('checked', false);
                $('.filter-size').prop('checked', false);
                $('.filter-type').prop('checked', false);

                filters = [];
            }
            else {
                $('.filter-all').prop('checked', false);

                if (checkbox.hasClass('filter-name')) {
                    $('.filter-name').prop('checked', false);

                    filters.splice($.inArray('name', filters), 1);
                }
                else if (checkbox.hasClass('filter-size')) {
                    $('.filter-size').prop('checked', false);

                    filters.splice($.inArray('size', filters), 1);
                }
                else if (checkbox.hasClass('filter-type')) {
                    $('.filter-type').prop('checked', false);

                    filters.splice($.inArray('type', filters), 1);
                }
            }
        }
        else {
            if (checkbox.hasClass('filter-all')) {
                checkbox.prop('checked', true);
                $('.filter-all').prop('checked', true);
                $('.filter-name').prop('checked', true);
                $('.filter-size').prop('checked', true);
                $('.filter-type').prop('checked', true);

                filters = ['name', 'size', 'type'];
            }
            else {
                if (checkbox.hasClass('filter-name')) {
                    $('.filter-name').prop('checked', true);

                    if (!filters.includes('name')) {
                        filters.push('name');
                    }
                }
                else if (checkbox.hasClass('filter-size')) {
                    $('.filter-size').prop('checked', true);

                    if (!filters.includes('size')) {
                        filters.push('size');
                    }
                }
                else if (checkbox.hasClass('filter-type')) {
                    $('.filter-type').prop('checked', true);

                    if (!filters.includes('type')) {
                        filters.push('type');
                    }
                }

                if (filters.length > 2) {
                    $('.filter-all').prop('checked', true);
                }
            }
        }

        autocomplete(searchInput, trs, filters);
        $('input[name="search"]').trigger('keyup');
        return false;
    });

    //autocomplete(searchInput, trs, filters);

    // Search Function
    searchInput.on('keyup', function () {
        let _this = $(this);
        let val = _this.val().toLowerCase();
        let shown = trs.length;

        // Tie both value and label state together
        searchInput.val(val);

        if (_this.val() !== '') {
            searchInput.parent().find('label').addClass('active');
        }
        else {
            searchInput.parent().find('label').removeClass('active');
        }

        trs.each(function () {
            let _this = $(this);

            if (val) {
                let tds = _this.children('td[headers]:not([headers="select"], [headers="actions"], [id="empty-search"])');
                let show = false;

                for (let i = 0, n = tds.length; i < n && !show; i++) {
                    td = $(tds[i]);

                    if (td.text().toLowerCase().indexOf(val) > -1 && filters.includes(td.attr('headers'))) {
                        show = true;
                    }
                }

                if (show && _this.attr('style')) {
                    _this.removeAttr('style');

                    _this.addClass('flipInX').one("animationend", function () {
                        _this.removeClass('flipInX');
                    });
                }
                else if (!show) {
                    if (!_this.attr('style')) {
                        _this.addClass('flipOutX').one("animationend", function () {
                            _this.removeClass('flipOutX');
                            _this.prop('style', 'display: none !important;');
                        });
                    }

                    shown--;
                }
            }
            else {
                if (_this.attr('style')) {
                    _this.removeAttr('style');
                    _this.addClass('flipInX').one("animationend", function () {
                        $(this).removeClass('flipInX');
                    });
                }
            }
        });

        $('#empty-search', '#files-table').remove();

        if (shown < 1) {
            $('tbody', '#files-table').prepend(`
                <tr id="empty-search">
                    <td class="rounded-bottom" colspan=100>
                        Couldn\'t find anything for <span class="font-weight-bolder">${val}</span>
                    </td>
                </tr>
            `);
        }
    });

    // Search Autocomplete
    //function autocomplete(searchInput, trs, filters) {
    //    let autocomplete = [];

    //    trs.each(function () {
    //        let tds = $(this).children('td:not([headers="select"], [headers="actions"])');

    //        for (let i = 0, n = tds.length; i < n; i++) {
    //            header = $(tds[i]).attr('headers');

    //            if (filters.includes(header)) {
    //                if (!autocomplete.hasOwnProperty(header)) {
    //                    autocomplete[header] = [$(tds[i]).text()];
    //                }
    //                else {
    //                    autocomplete[header].push($(tds[i]).text());
    //                }
    //            }
    //        }
    //    });

    //    let data = Object.keys(autocomplete).reduce(function (arr, k) {
    //        return Array.from(new Set(arr.concat(autocomplete[k])));
    //    }, []);

    //    let wrapper = $('.mdb-autocomplete-wrap', '#action-search, #mobile-search');
    //    wrapper.remove();

    //    searchInput.mdbAutocomplete({ data: data });

    //    if (data.length > 0) {
    //        let autocompleteClear = searchInput.next().next('.mdb-autocomplete-clear');

    //        autocompleteClear.removeClass('d-none');

    //        wrapper.on('click', function () {
    //            return false;
    //        });

    //        searchInput.next('.mdb-autocomplete-wrap').on('click', function () {
    //            $(this).prev('.mdb-autocomplete').trigger('keyup');
    //            $(this).html('');
    //        });

    //        autocompleteClear.on('click', function () {
    //            $(this).prev().prev('.mdb-autocomplete').trigger('keyup');
    //        });
    //    }
    //    else {
    //        searchInput.next('.mdb-autocomplete-clear').addClass('d-none');
    //    }
    //}
});
