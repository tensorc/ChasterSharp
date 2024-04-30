using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ChasterSharp
{

    public sealed class ChasterClient
    {
        #region Members

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

        public ChasterClient(HttpClient httpClient, string? bearerToken = null)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.chaster.app");

            if (!string.IsNullOrEmpty(bearerToken)) _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        #endregion

        #region Files

        //TODO: Test this, also it appears to support multiple files but only returns 1 Token?
        public async Task<ApiResult<string?>> UploadFilesAsync(UploadFilesDto uploadFiles, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(uploadFiles, nameof(uploadFiles));

            using MultipartFormDataContent multipartContent = [];

            foreach (var file in uploadFiles.Files)
            {
                using ByteArrayContent byteContent = new(file.Data);

                if (!string.IsNullOrEmpty(file.ContentType)) byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

                multipartContent.Add(byteContent, "files", file.FileName ?? Guid.NewGuid().ToString());
            }

            using StringContent fileTypeContent = new(EnumStringConverter.GetMemberValueFromEnum(uploadFiles.Type)!);
            multipartContent.Add(fileTypeContent, "type");

            var result = await PostContentAsync("files/upload", content: multipartContent, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<UploadFilesRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.Token, result);
        }

        public async Task<ApiResult<Uri?>> GetFileUrlAsync(string fileKey, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileKey, nameof(fileKey));

            var result = await GetAsync($"files/{fileKey}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<FileFromKeyRepDto>().ConfigureAwait(false);

            return WrapResult<Uri?>(output?.Url, result);
        }

        #endregion

        #region Reports

        public async Task<ApiResult> CreateReportAsync(CreateReportDto createReport, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(createReport, nameof(createReport));

            return await PutObjectAsync("reports", obj: createReport, bearerToken: bearerToken).ConfigureAwait(false);
        }

        #endregion

        #region Shared Locks

        public async Task<ApiResult<List<SharedLockForPublic>?>> GetSharedLocksAsync(SharedLockStatus? status = null, string? bearerToken = null)
        {
            Dictionary<string, string> parameters = [];

            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);

            var result = await GetAsync("locks/shared-locks", parameters, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<SharedLockForPublic>>().ConfigureAwait(false);

            return WrapResult<List<SharedLockForPublic>?>(output, result);
        }

        public async Task<ApiResult<string?>> CreateSharedLockAsync(CreateUpdateSharedLockDto createUpdateSharedLock, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(createUpdateSharedLock, nameof(createUpdateSharedLock));

            var result = await PostObjectAsync("locks/shared-locks", obj: createUpdateSharedLock, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CreateSharedLockRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.Id, result);
        }

        public async Task<ApiResult<SharedLockForPublic?>> GetSharedLockAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"locks/shared-locks/{sharedLockId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<SharedLockForPublic>().ConfigureAwait(false);

            return WrapResult<SharedLockForPublic?>(output, result);
        }

        public async Task<ApiResult> UpdateSharedLockAsync(string sharedLockId, CreateUpdateSharedLockDto createUpdateSharedLock, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));
            ArgumentNullException.ThrowIfNull(createUpdateSharedLock, nameof(createUpdateSharedLock));

            return await PutObjectAsync($"locks/shared-locks/{sharedLockId}", obj: createUpdateSharedLock, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> UpdateSharedLockExtensionsAsync(string sharedLockId, EditLockExtensionsDto editLockExtensions, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));
            ArgumentNullException.ThrowIfNull(editLockExtensions);

            return await PutObjectAsync($"locks/shared-locks/{sharedLockId}/extensions", obj: editLockExtensions, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> ArchiveSharedLockAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            return await PostObjectAsync($"locks/shared-locks/{sharedLockId}/archive", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<bool?>> GetSharedLockIsFavoriteAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"shared-locks/{sharedLockId}/favorite", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<IsFavoriteSharedLockRepDto>().ConfigureAwait(false);

            return WrapResult(output?.Favorite, result);
        }

        public async Task<ApiResult> FavoriteSharedLockAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            return await PutObjectAsync($"shared-locks/{sharedLockId}/favorite", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> UnfavoriteSharedLockAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            return await DeleteAsync($"shared-locks/{sharedLockId}/favorite", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<FavoriteSharedLocksRepDto?>> GetFavoriteSharedLocksAsync(FavoriteSharedLocksDto getFavoriteSharedLocks, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(getFavoriteSharedLocks);

            var result = await PostObjectAsync("favorites/shared-locks", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<FavoriteSharedLocksRepDto>().ConfigureAwait(false);

            return WrapResult<FavoriteSharedLocksRepDto?>(output, result);
        }

        #endregion

        #region Locks
        
        public async Task<ApiResult<List<Lock>?>> GetLocksAsync(UserLockStatus? status = null, string? bearerToken = null)
        {
            Dictionary<string, string> parameters = [];

            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);

            var result = await GetAsync("locks", parameters, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<Lock>>().ConfigureAwait(false);

            return WrapResult<List<Lock>?>(output, result);
        }

        public async Task<ApiResult<Lock?>> GetLockAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<Lock>().ConfigureAwait(false);

            return WrapResult<Lock?>(output, result);
        }

        public async Task<ApiResult> ArchiveLockAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            return await PostObjectAsync($"locks/{lockId}/archive", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> ArchiveKeyholderLockAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            return await PostObjectAsync($"locks/{lockId}/archive/keyholder", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> AddLockTimeAsync(string lockId, int timeToAdd, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            UpdateTimeDto dto = new() { Duration = timeToAdd };

            return await PostObjectAsync($"locks/{lockId}/update-time", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> SetLockFreezeAsync(string lockId, bool isFrozen, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            SetFreezeDto dto = new() { IsFrozen = isFrozen };

            return await PostObjectAsync($"locks/{lockId}/freeze", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> UnlockLockAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            return await PostObjectAsync($"locks/{lockId}/unlock", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> SetLockTimeInfoAsync(string lockId, bool? displayRemainingTime, bool? hideTimeLogs, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            SetLockSettingsDto dto = new() { DisplayRemainingTime = displayRemainingTime, HideTimeLogs = hideTimeLogs };

            return await PostObjectAsync($"locks/{lockId}/settings", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> SetLockMaxLimitDateAsync(string lockId, DateTimeOffset maxLimitDate, bool disableMaxLimitDate, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            IncreaseMaxLimitDateDto dto = new() { MaxLimitDate = maxLimitDate, DisableMaxLimitDate = disableMaxLimitDate };

            return await PostObjectAsync($"locks/{lockId}/max-limit-date", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> TrustLockKeyholderAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            return await PostObjectAsync($"locks/{lockId}/trust-keyholder", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<CombinationForPublic?>> GetLockCombinationAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}/combination", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);

            return WrapResult<CombinationForPublic?>(output, result);
        }

        public async Task<ApiResult<HistoryRepDto?>> GetLockHistoryAsync(string lockId, LockHistoryDto getLockHistory, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentNullException.ThrowIfNull(getLockHistory);

            var result = await PostObjectAsync($"locks/{lockId}/history", obj: getLockHistory, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<HistoryRepDto>().ConfigureAwait(false);

            return WrapResult<HistoryRepDto?>(output, result);
        }

        public async Task<ApiResult> SetLockAsTestAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            return await PutObjectAsync($"locks/{lockId}/is-test-lock", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<LockInfoFromExtensionRepDto?>> GetLockExtensionInfoAsync(string lockId, string extensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(extensionId, nameof(extensionId));

            var result = await GetAsync($"locks/{lockId}/extensions/{extensionId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LockInfoFromExtensionRepDto>().ConfigureAwait(false);

            return WrapResult<LockInfoFromExtensionRepDto?>(output, result);
        }

        public async Task<ApiResult> TriggerLockActionAsync(string lockId, string extensionId, TriggerExtensionActionDto triggerExtensionAction, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(extensionId, nameof(extensionId));
            ArgumentNullException.ThrowIfNull(triggerExtensionAction);

            return await PostObjectAsync($"locks/{lockId}/extensions/{extensionId}/action", obj: triggerExtensionAction, bearerToken: bearerToken).ConfigureAwait(false);
        }

        #endregion

        #region LockId Creation

        public async Task<ApiResult<string?>> CreateLockAsync(CreateLockDto createLock, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(createLock);

            var result = await PostObjectAsync("locks", obj: createLock, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LockCreatedRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.LockId, result);
        }

        public async Task<ApiResult> UpdateLockExtensionsAsync(string lockId, EditLockExtensionsDto editLockExtensions, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId)); 
            ArgumentNullException.ThrowIfNull(editLockExtensions);

            return await PostObjectAsync($"locks/{lockId}/extensions", obj: editLockExtensions, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<string?>> CreateLockFromSharedLockAsync(string sharedLockId, CreateLockFromSharedLockDto createLockFromSharedLock, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId)); 
            ArgumentNullException.ThrowIfNull(createLockFromSharedLock);

            var result = await PostObjectAsync($"public-locks/{sharedLockId}/create-lock", obj: createLockFromSharedLock, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LockCreatedRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.LockId, result);
        }

        #endregion

        #region Profile

        public async Task<ApiResult<List<Lock>?>> GetUserLocksAsync(string userId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"locks/user/{userId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<Lock>>().ConfigureAwait(false);

            return WrapResult<List<Lock>?>(output, result);
        }

        public async Task<ApiResult<UserForPublic?>> GetUserAsync(string userId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"users/profile/by-id/{userId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);

            return WrapResult<UserForPublic?>(output, result);
        }

        public async Task<ApiResult<UserForPublic?>> GetUserByNameAsync(string userName, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            var result = await GetAsync($"users/profile/{userName}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);

            return WrapResult<UserForPublic?>(output, result);
        }

        public async Task<ApiResult<ProfileRepDto?>> GetUserDetailsAsync(string userName, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            var result = await GetAsync($"users/profile/{userName}/details", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ProfileRepDto>().ConfigureAwait(false);

            return WrapResult<ProfileRepDto?>(output, result);
        }

        public async Task<ApiResult<UserBadgeCount?>> GetBadgeCountsAsync(string? bearerToken = null)
        {
            var result = await GetAsync("users/badge/count", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<UserBadgeCount>().ConfigureAwait(false);

            return WrapResult<UserBadgeCount?>(output, result);
        }

        public async Task<ApiResult<CurrentUserForProfileSettings?>> GetUserProfileInfoAsync(string? bearerToken = null)
        {
            var result = await GetAsync("auth/profile/update", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CurrentUserForProfileSettings>().ConfigureAwait(false);

            return WrapResult<CurrentUserForProfileSettings?>(output, result);
        }

        public async Task<ApiResult<CurrentUser?>> GetUserInfoAsync(string? bearerToken = null)
        {
            var result = await GetAsync("auth/profile", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CurrentUser>().ConfigureAwait(false);

            return WrapResult<CurrentUser?>(output, result);
        }

        #endregion

        #region Combinations

        //TODO: Test this
        public async Task<ApiResult<string?>> UploadCombinationImageAsync(UploadCombinationImageDto uploadCombinationImage, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(uploadCombinationImage);

            using MultipartFormDataContent multipartContent = [];
            using ByteArrayContent byteContent = new(uploadCombinationImage.File.Data);

            if (!string.IsNullOrEmpty(uploadCombinationImage.File.ContentType)) byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse(uploadCombinationImage.File.ContentType);

            multipartContent.Add(byteContent, "file", uploadCombinationImage.File.FileName ?? Guid.NewGuid().ToString());

            if (uploadCombinationImage.EnableManualCheck is not null)
            {
                using StringContent fileTypeContent = new(uploadCombinationImage.EnableManualCheck.ToString()!);
                multipartContent.Add(fileTypeContent, "enableManualCheck");
            }

            var result = await PostContentAsync("combinations/image", content: multipartContent, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CreateCodeRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.CombinationId, result);
        }

        public async Task<ApiResult<string?>> CreateCodeCombinationAsync(string code, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));

            CreateCodeDto dto = new() { Code = code };

            var result = await PostObjectAsync("combinations/code", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CreateCodeRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.CombinationId, result);
        }

        #endregion

        #region Extensions

        public async Task<ApiResult<List<ExtensionForPublic>?>> GetExtensionsAsync(string? bearerToken = null)
        {
            var result = await GetAsync("extensions", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<ExtensionForPublic>>().ConfigureAwait(false);

            return WrapResult<List<ExtensionForPublic>?>(output, result);
        }

        #endregion

        #region Session Offer

        public async Task<ApiResult> CreateKeyholdingOfferAsync(string lockId, string keyholderUserName, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(keyholderUserName, nameof(keyholderUserName));

            CreateOfferRequestDto dto = new() { Keyholder = keyholderUserName };

            return await PostObjectAsync($"session-offer/lock/{lockId}", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> AcceptKeyholdingRequestAsync(string offerToken, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(offerToken, nameof(offerToken));

            return await GetAsync($"session-offer/token/{offerToken}/accept", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<List<SessionOfferRequestForPublic>?>> GetKeyholdingOffersAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"session-offer/lock/{lockId}/status", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<SessionOfferRequestForPublic>>().ConfigureAwait(false);

            return WrapResult<List<SessionOfferRequestForPublic>?>(output, result);
        }

        public async Task<ApiResult<Lock?>> GetLockByKeyholdingOfferAsync(string offerToken, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(offerToken, nameof(offerToken));

            var result = await GetAsync($"session-offer/token/{offerToken}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<Lock>().ConfigureAwait(false);

            return WrapResult<Lock?>(output, result);
        }

        public async Task<ApiResult> RespondToKeyholdingOfferAsync(string sessionRequestId, bool accept, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionRequestId, nameof(sessionRequestId));

            ValidateOfferRequestDto dto = new() { Accept = accept };

            return await PostObjectAsync($"session-offer/{sessionRequestId}", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> ArchiveKeyholdingOfferAsync(string sessionRequestId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionRequestId, nameof(sessionRequestId));

            return await GetAsync($"session-offer/{sessionRequestId}/archive", bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<List<SessionOfferRequestForKeyholder>?>> GetKeyholdingRequestsAsync(string? bearerToken = null)
        {
            var result = await GetAsync("session-offer/requests", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<SessionOfferRequestForKeyholder>>().ConfigureAwait(false);

            return WrapResult<List<SessionOfferRequestForKeyholder>?>(output, result);
        }

        #endregion

        #region Messaging

        //NOTE: Limit has a range of 1-100, offset should be the value returned from a previous call
        public async Task<ApiResult<ConversationsRepDto?>> GetConversationsAsync(int? limit = null, ConversationStatus? status = null, DateTimeOffset? offset = null, string? bearerToken = null)
        {
            Dictionary<string, string> parameters = [];

            if (limit is not null) parameters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));
            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);
            if (offset is not null) parameters.Add("offset", offset.ToString()!);

            var result = await GetAsync("conversations", parameters, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ConversationsRepDto>().ConfigureAwait(false);

            return WrapResult<ConversationsRepDto?>(output, result);
        }

        public async Task<ApiResult<ConversationForPublic?>> CreateConversationAsync(CreateConversationDto createConversation, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(createConversation);

            var result = await PostObjectAsync("conversations", obj: createConversation, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);

            return WrapResult<ConversationForPublic?>(output, result);
        }

        public async Task<ApiResult<ConversationForPublic?>> GetConversationByUserIdAsync(string userId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"conversations/by-user/{userId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);

            return WrapResult<ConversationForPublic?>(output, result);
        }

        public async Task<ApiResult<MessageForPublic?>> AddMessageToConversationAsync(string conversationId, UpdateConversationDto updateConversation, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));
            ArgumentNullException.ThrowIfNull(updateConversation);

            var result = await PostObjectAsync($"conversations/{conversationId}", obj: updateConversation, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<MessageForPublic>().ConfigureAwait(false);

            return WrapResult<MessageForPublic?>(output, result);
        }

        public async Task<ApiResult<ConversationForPublic?>> GetConversationAsync(string conversationId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            var result = await GetAsync($"conversations/{conversationId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);

            return WrapResult<ConversationForPublic?>(output, result);
        }

        public async Task<ApiResult> SetConversationStatusAsync(string conversationId, SetConversationStatusDtoStatus status, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            SetConversationStatusDto dto = new() { Status = status };

            return await PutObjectAsync($"conversations/{conversationId}/status", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> SetConversationStatusAsync(string conversationId, bool unread, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            SetConversationUnreadDto dto = new() { Unread = unread };

            return await PutObjectAsync($"conversations/{conversationId}/unread", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        //NOTE: Limit has a range of 1-100
        public async Task<ApiResult<MessagesRepDto?>> GetConversationMessagesAsync(string conversationId, int? limit = null, string? lastId = null, string? bearerToken = null)
        {
            Dictionary<string, string> parameters = [];

            if (limit is not null) parameters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));
            if (lastId is not null) parameters.Add("lastId", lastId);

            var result = await GetAsync($"conversations/{conversationId}/messages", parameters, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<MessagesRepDto>().ConfigureAwait(false);

            return WrapResult<MessagesRepDto?>(output, result);
        }

        #endregion

        #region Extensions - Temporary Opening

        public async Task<ApiResult<CombinationForPublic?>> GetTemporaryOpeningLockCombinationAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"extensions/temporary-opening/{lockId}/combination", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);

            return WrapResult<CombinationForPublic?>(output, result);
        }

        public async Task<ApiResult> SetTemporaryOpeningCombinationAsync(string lockId, string combinationId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            TemporaryOpeningSetCombinationDto dto = new() { CombinationId = combinationId };

            return await PostObjectAsync($"extensions/temporary-opening/{lockId}/combination", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<CombinationForPublic?>> GetTemporaryOpeningLockCombinationFromActionLogAsync(string lockId, string actionLogId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(actionLogId, nameof(actionLogId));

            var result = await GetAsync($"/extensions/temporary-opening/{lockId}/action-log/{actionLogId}/combination", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);

            return WrapResult<CombinationForPublic?>(output, result);
        }


        #endregion

        #region Community Events

        public async Task<ApiResult<List<CommunityEventCategory>?>> GetCommunityEventCategoriesAsync(string? bearerToken = null)
        {
            var result = await GetAsync("community-event/categories", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<CommunityEventCategory>>().ConfigureAwait(false);

            return WrapResult<List<CommunityEventCategory>?>(output, result);
        }

        public async Task<ApiResult<PeriodDetailsRepDto?>> GetCommunityEventTaskDetailsAsync(DateTimeOffset date, string? bearerToken = null)
        {
            PeriodDetailsDto dto = new() { Date = date };

            var result = await PostObjectAsync("community-event/details", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<PeriodDetailsRepDto>().ConfigureAwait(false);

            return WrapResult<PeriodDetailsRepDto?>(output, result);
        }

        #endregion

        #region Settings

        public async Task<ApiResult<AppSettingsDto?>> GetAppSettingsAsync(string? bearerToken = null)
        {
            var result = await GetAsync("settings", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<AppSettingsDto>().ConfigureAwait(false);

            return WrapResult<AppSettingsDto?>(output, result);
        }

        #endregion

        #region Users

        public async Task<ApiResult<List<UserForPublic>?>> SearchUsersAsync(string userName, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            SearchUserUsernameDto dto = new() { Search = userName };

            var result = await PostObjectAsync("users/search/by-username", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<UserForPublic>>().ConfigureAwait(false);

            return WrapResult<List<UserForPublic>?>(output, result);
        }

        public async Task<ApiResult<UserForPublic?>> GetUserByDiscordIdAsync(string discordId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(discordId, nameof(discordId));

            var result = await GetAsync($"users/search/by-discord-id/{discordId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);

            return WrapResult<UserForPublic?>(output, result);
        }

        #endregion

        #region Keyholder

        public async Task<ApiResult<KeyholderSearchLocksRepDto?>> SearchLockedUsersAsync(KeyholderSearchLocksDto keyholderSearchLocks, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(keyholderSearchLocks);

            var result = await PostObjectAsync("keyholder/locks/search", obj: keyholderSearchLocks, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<KeyholderSearchLocksRepDto>().ConfigureAwait(false);

            return WrapResult<KeyholderSearchLocksRepDto?>(output, result);
        }

        #endregion

        #region Public Locks

        public async Task<ApiResult<PublicLockForPublic?>> GetPublicLockAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"public-locks/{sharedLockId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<PublicLockForPublic>().ConfigureAwait(false);

            return WrapResult<PublicLockForPublic?>(output, result);
        }

        /// <summary>
        /// Return a PNG preview of a lock for sharing on social media
        /// </summary>
        public async Task<ApiResult<byte[]?>> GetLockImageAsync(string sharedLockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"public-locks/images/{sharedLockId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetBytesAsync().ConfigureAwait(false);

            return WrapResult<byte[]?>(output, result);
        }

        public async Task<ApiResult<SearchPublicLockRepDto?>> SearchPublicLocksAsync(SearchPublicLockDto searchPublicLock, string? bearerToken = null)
        {
            ArgumentNullException.ThrowIfNull(searchPublicLock);

            var result = await PostObjectAsync("public-locks/search", obj: searchPublicLock, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<SearchPublicLockRepDto>().ConfigureAwait(false);

            return WrapResult<SearchPublicLockRepDto?>(output, result);
        }

        public async Task<ApiResult<List<ExploreCategoryForPublic>?>> GetPublicLocksFromExplorePageAsync(string? bearerToken = null)
        {
            var result = await GetAsync("/explore/categories", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<ExploreCategoryForPublic>>().ConfigureAwait(false);

            return WrapResult<List<ExploreCategoryForPublic>?>(output, result);
        }

        #endregion

        #region Extensions - Verification Picture

        //TODO: Test this, and check if contentType is allowed
        public async Task<ApiResult> UploadVerificationPictureAsync(string lockId, byte[] data, string? contentType = null, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentNullException.ThrowIfNull(data);

            using ByteArrayContent byteContent = new(data);

            if (!string.IsNullOrEmpty(contentType)) byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

            return await PostContentAsync($"extensions/verification-picture/{lockId}/submit", content: byteContent, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<List<VerificationPictureHistoryEntry>?>> GetVerificationPicturesAsync(string lockId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}/verification-pictures", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<VerificationPictureHistoryEntry>>().ConfigureAwait(false);

            return WrapResult<List<VerificationPictureHistoryEntry>?>(output, result);
        }

        #endregion

        #region Extensions - Share Links

        public async Task<ApiResult<LinkInfoActionRepDto?>> GetShareLinkInfoFromSessionIdAsync(string sessionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionId, nameof(sessionId));

            var result = await GetAsync($"shared-links/{sessionId}", bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LinkInfoActionRepDto>().ConfigureAwait(false);

            return WrapResult<LinkInfoActionRepDto?>(output, result);
        }

        #endregion

        #region Extension Actions

        public async Task<ApiResult> ResolveTaskAsync(string lockId, string tasksExtensionId, bool isCompleted, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "completeTask",
                Payload = JsonSerializer.SerializeToElement(new ResolveTaskActionModel { IsCompleted = isCompleted })
            };

            return await TriggerLockActionAsync(lockId, tasksExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<int?>> ShareLinkVoteAsync(string lockId, string linkExtensionId, string sessionId, ShareLinkVoteAction voteAction, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));
            
            TriggerExtensionActionDto dto = new()
            {
                Action = "vote",
                Payload = JsonSerializer.SerializeToElement(new ShareLinkeVoteActionModel { Action = voteAction, SessionId = sessionId})
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<ShareLinkVoteActionRepDto>().ConfigureAwait(false);

            return WrapResult(output?.Duration, result);
        }

        public async Task<ApiResult<SpinWheelActionModel?>> SpinWheelOfFortuneAsync(string lockId, string wheelOfFortuneExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(wheelOfFortuneExtensionId, nameof(wheelOfFortuneExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, wheelOfFortuneExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<SpinWheelActionModel>().ConfigureAwait(false);

            return WrapResult<SpinWheelActionModel?>(output, result);
        }

        public async Task<ApiResult<RollDiceActionModel?>> RollDiceAsync(string lockId, string diceExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(diceExtensionId, nameof(diceExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, diceExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<RollDiceActionModel>().ConfigureAwait(false);

            return WrapResult<RollDiceActionModel?>(output, result);
        }

        public async Task<ApiResult> PilloryLockAsync(string lockId, string pilloryExtensionId, string? reason, int duration, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(pilloryExtensionId, nameof(pilloryExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new PilloryLockActionParamsModel { Reason = reason, Duration = duration })
            };

            return await TriggerLockActionAsync(lockId, pilloryExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<List<PilloryVoteInfoActionRepDto>?>> GetPilloryVoteInfoAsync(string lockId, string pilloryExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(pilloryExtensionId, nameof(pilloryExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getStatus"
            };

            var result = await TriggerLockActionAsync(lockId, pilloryExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<List<PilloryVoteInfoActionRepDto>>().ConfigureAwait(false);

            return WrapResult<List<PilloryVoteInfoActionRepDto>?>(output, result);
        }

        public async Task<ApiResult> UpdateLockTasksAsync(string lockId, string tasksExtensionId, List<TaskActionParamsModel> tasks, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "updateTasks",
                Payload = JsonSerializer.SerializeToElement(new UpdateTasksActionModel { Tasks = tasks })
            };

            return await TriggerLockActionAsync(lockId, tasksExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> AssignTaskAsync(string lockId, string tasksExtensionId, TaskActionParamsModel task, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "assignTask",
                Payload = JsonSerializer.SerializeToElement(new AssignTaskActionModel { Task = task })
            };

            return await TriggerLockActionAsync(lockId, tasksExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> AssignRandomTaskAsync(string lockId, string tasksExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new AssignVoteTaskActionModel())
            };

            return await TriggerLockActionAsync(lockId, tasksExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> AssignVoteTaskAsync(string lockId, string tasksExtensionId, int duration, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new AssignVoteTaskActionModel { RequestVote = true, VoteDuration = duration })
            };

            return await TriggerLockActionAsync(lockId, tasksExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<string?>> GetShareLinkAsync(string lockId, string linkExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getLink"
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LinkActionRepDto>().ConfigureAwait(false);

            return WrapResult<string?>(output?.Link, result);
        }

        public async Task<ApiResult<LinkInfoActionRepDto?>> GetShareLinkInfoAsync(string lockId, string linkExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getInfo"
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<LinkInfoActionRepDto>().ConfigureAwait(false);

            return WrapResult<LinkInfoActionRepDto?>(output, result);
        }

        public async Task<ApiResult> CreateVerificationPictureRequestAsync(string lockId, string verificationPictureExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(verificationPictureExtensionId, nameof(verificationPictureExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "createVerificationRequest"
            };

            return await TriggerLockActionAsync(lockId, verificationPictureExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> KeyholderTemporarilyUnlockAsync(string lockId, string temporaryOpeningExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(temporaryOpeningExtensionId, nameof(temporaryOpeningExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "keyholderOpen"
            };

            return await TriggerLockActionAsync(lockId, temporaryOpeningExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult> WearerTemporarilyUnlockAsync(string lockId, string temporaryOpeningExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(temporaryOpeningExtensionId, nameof(temporaryOpeningExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            return await TriggerLockActionAsync(lockId, temporaryOpeningExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
        }

        public async Task<ApiResult<GuessTheTimerActionRepDto?>> SubmitGuessToGuessTheTimerAsync(string lockId, string guessTheTimerExtensionId, string? bearerToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(guessTheTimerExtensionId, nameof(guessTheTimerExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, guessTheTimerExtensionId, dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<GuessTheTimerActionRepDto>().ConfigureAwait(false);

            return WrapResult<GuessTheTimerActionRepDto?>(output, result);
        }

        #endregion

        #region Activity

        public async Task<ApiResult<PostsRepDto?>> GetPublicActivityAsync(string? bearerToken = null)
        {
            //NOTE: The API ignores the GetPostsDto, but we'll leave this here just in case.
            PostsDto dto = new() { Limit = 10 };

            var result = await PostObjectAsync("posts", obj: dto, bearerToken: bearerToken).ConfigureAwait(false);
            var output = await result.GetObjectAsync<PostsRepDto>().ConfigureAwait(false);

            return WrapResult<PostsRepDto?>(output, result);
        }

        #endregion

        #region Http Handling

        private async Task<ApiResult> GetAsync(string relativeUri, Dictionary<string, string>? parameters = null, string? bearerToken = null)
        {
            using HttpRequestMessage request = new(HttpMethod.Get, BuildUrl(relativeUri, parameters));

            if (!string.IsNullOrEmpty(bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return await GetResultAsync(request).ConfigureAwait(false);
        }

        private async Task<ApiResult> PostObjectAsync(string relativeUri, Dictionary<string, string>? parameters = null, object? obj = null, string? bearerToken = null)
        {
            using HttpRequestMessage request = new(HttpMethod.Post, BuildUrl(relativeUri, parameters));
            request.Content = obj is null ? null : new StringContent(JsonSerializer.Serialize(obj), MediaTypeHeaderValue.Parse("application/json"));

            if (!string.IsNullOrEmpty(bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return await GetResultAsync(request).ConfigureAwait(false);
        }

        private async Task<ApiResult> PostContentAsync(string relativeUri, Dictionary<string, string>? parameters = null, HttpContent? content = null, string? bearerToken = null)
        {
            using HttpRequestMessage request = new(HttpMethod.Post, BuildUrl(relativeUri, parameters));
            request.Content = content;

            if (!string.IsNullOrEmpty(bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return await GetResultAsync(request).ConfigureAwait(false);
        }

        private async Task<ApiResult> PutObjectAsync(string relativeUri, Dictionary<string, string>? parameters = null, object? obj = null, string? bearerToken = null)
        {
            using HttpRequestMessage request = new(HttpMethod.Put, BuildUrl(relativeUri, parameters));
            request.Content = obj is null ? null : new StringContent(JsonSerializer.Serialize(obj), MediaTypeHeaderValue.Parse("application/json"));

            if (!string.IsNullOrEmpty(bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return await GetResultAsync(request).ConfigureAwait(false);
        }

        private async Task<ApiResult> DeleteAsync(string relativeUri, Dictionary<string, string>? parameters = null, string? bearerToken = null)
        {
            using HttpRequestMessage request = new(HttpMethod.Delete, BuildUrl(relativeUri, parameters));

            if (!string.IsNullOrEmpty(bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return await GetResultAsync(request).ConfigureAwait(false);
        }

        private async Task<ApiResult> GetResultAsync(HttpRequestMessage request)
        {
            try
            {
                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                _ = response.EnsureSuccessStatusCode();

                return new ApiResult(response, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode is >= HttpStatusCode.BadRequest and <= HttpStatusCode.InternalServerError && ex.StatusCode != HttpStatusCode.RequestTimeout && ex.StatusCode != HttpStatusCode.TooManyRequests)
                {
                    return new ApiResult(null, ex.StatusCode);
                }

                throw;
            }
        }

        private static string BuildUrl(string relativeUri, Dictionary<string, string>? parameters = null)
        {
            StringBuilder builder = new();
            _ = builder.Append(relativeUri);

            if (parameters is not null && parameters.Count > 0)
            {
                _ = builder.Append('?');

                foreach (var parameter in parameters) _ = builder.Append(CultureInfo.InvariantCulture, $"{WebUtility.UrlEncode(parameter.Key)}={WebUtility.UrlEncode(parameter.Value)}&");

                builder.Length--;
            }

            return builder.ToString();
        }

        private static ApiResult<T?> WrapResult<T>(T? value, ApiResult apiResult)
        {
            ArgumentNullException.ThrowIfNull(apiResult, nameof(apiResult));
            return new ApiResult<T?>(value, apiResult.HttpResponse, apiResult.StatusCode);
        }

        #endregion

    }
}