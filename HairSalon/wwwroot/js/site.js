$(document).ready(function() {
    $('.delete-link').on('click', function(e) {
        e.preventDefault(); 

        let stylistId = $(this).attr('data-id');
        let url = "/Stylists/Delete/" + stylistId;
        
        if (confirm('Are you sure you want to delete this stylist?')) {
            $.ajax({
                url: url,
                type: 'POST',
                data: { id: stylistId },
                success: function(result) {
                    location.reload();
                },
                error: function(result) {
                    alert("Error deleting stylist. Please try again later.");
                }
            });
        }
    });
});
