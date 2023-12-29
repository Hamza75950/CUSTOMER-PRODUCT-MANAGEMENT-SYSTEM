
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <script>
        // Show loader when navigating to a new page
        $(document).on('click', 'a', function() {
            showLoader();
    });

    // Hide loader when the page has finished loading
    $(document).ready(function() {
            hideLoader();
    });

    function showLoader() {
            $('#loader').show();
    }

    function hideLoader() {
            $('#loader').hide();
    }
</script>
