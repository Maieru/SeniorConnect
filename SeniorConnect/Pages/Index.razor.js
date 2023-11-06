document.getElementById('contactButton').addEventListener('click', function () {
    var modal = document.getElementById('contactModal');
    modal.style.display = 'block';
});

document.getElementById('closeModal').addEventListener('click', function () {
    var modal = document.getElementById('contactModal');
    modal.style.display = 'none';
});