// Utilizing AJAX to asynchronously delete a stylist after user-confirmation.
const deleteLinks = document.querySelectorAll('.delete-link');

// Create click handler for every deleteLink element.
deleteLinks.forEach((deleteLink) => {
    deleteLink.addEventListener('click', (e) => {
        e.preventDefault(); 

        // Grab the stylistId from the data-id attribute.
        let stylistId = deleteLink.getAttribute('data-id');
        let url = "/Stylists/Delete/" + stylistId;
        
        // Ask user for confirmation.
        if (confirm('Are you sure you want to delete this stylist?')) {
            // Initiates an AJAX request on confirmation.
            $.ajax({
                // Route and type of request.
                url: url,
                type: 'POST',
                // Delete route requires an Id.
                data: { id: stylistId },
                // The controller sends back Ok() if successful.
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
