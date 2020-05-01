var photoAlbum = (function () {

    var init = function () {

        $ddAlbums.on('change', function () {
            loadPhotos($ddAlbums.val());
        });
    }

    var $ddAlbums = $('#ddAlbums');
    var $divPhotos = $('#photos');

    var loadPhotos = function (albumId) {

        $.ajax({

            url: "GetPhotosByAlbumId/" + albumId,
            success : function (data) {
                $divPhotos.html(data);
            }
        });
    }

    return {
        init: init
    };
})();

photoAlbum.init();