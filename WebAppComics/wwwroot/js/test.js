const CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/ddt8drwas/upload';
const CLOUDINARY_UPLOAD_PRESET = 'qtajqz06';
const image = document.querySelector('#fileupload');
image.addEventListener('change', (e) => {


    const formData = new FormData();
    let length = parseInt(document.getElementById("countFile").value);
   /* let length = parseInt(document.getElementById("countFile").name);*/
    for (let i = 0; i < length; i++) {
        const file = e.target.files[i];

        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);

        fetch(CLOUDINARY_URL, {
            method: 'POST',
            body: formData,
        })
            .then(response => response.json())
            .then((data) => {
                if (data.secure_url !== '') {
                    const uploadedFileUrl = data.secure_url;
                    localStorage.setItem('passportUrl', uploadedFileUrl)
                    var url = data.secure_url;
                    document.getElementById('image').src = url;
                    var t = document.getElementById('domain').value + "@" + url;
                    document.getElementById('domain').value = t;
                    //if (i == length - 1) {
                    //    document.getElementById("myForm").submit();
                    //}
                }
                else { alert('upload thất bại'); }
            })
            .catch(err => console.error(err));
    }
});
