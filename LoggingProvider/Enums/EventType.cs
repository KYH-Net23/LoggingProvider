namespace LoggingProvider.Enums
{
    public enum EventType
    {
        LogIn,
        LogOut,
        Register,
        PasswordResetRequest,
        PasswordResetComplete,

        PageView,
        PageLeave,
        Search,
        Click,
        Navigation,

        ButtonClick,
        FormSubmission,
        DropdownSelection,

        ItemView,
        ItemAddToCart,
        ItemRemoveFromCart,
        CheckoutInitiated,
        CheckoutCompleted,
        WishlistAdd,
        WishlistRemove,

        ReviewSubmission,

        ProfileView,
        ProfileUpdated,
        AccountDeletion,

        AdminLogin,
        UserBan,
        PermissionUpdate,

        Error,
        ApiFailure,

        CustomEvent
    }
}