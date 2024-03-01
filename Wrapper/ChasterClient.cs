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

        public ChasterClient(HttpClient httpClient, string? bearerToken)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.chaster.app");

            if (!string.IsNullOrEmpty(bearerToken)) _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        #endregion

        #region Files

        //TODO: Test this, also it appears to support multiple files but only returns 1 Token?
        public async Task<string?> UploadFilesAsync(UploadFilesDto uploadFiles)
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

            var result = await PostContentAsync("files/upload", content: multipartContent).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<UploadFilesRepDto>().ConfigureAwait(false);
            return output?.Token;
        }

        public async Task<Uri?> GetFileUrlAsync(string fileKey)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileKey, nameof(fileKey));

            var result = await GetAsync($"files/{fileKey}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<FileFromKeyRepDto>().ConfigureAwait(false);
            return output?.Url;
        }

        #endregion

        #region Reports

        public async Task CreateReportAsync(CreateReportDto createReport)
        {
            ArgumentNullException.ThrowIfNull(createReport, nameof(createReport));

            var result = await PutObjectAsync("reports", obj: createReport).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        #endregion

        #region Shared Locks

        public async Task<SharedLockForPublic[]?> GetSharedLocksAsync(SharedLockStatus? status = null)
        {
            Dictionary<string, string> parameters = [];

            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);

            var result = await GetAsync("locks/shared-locks", parameters).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<SharedLockForPublic[]>().ConfigureAwait(false);
        }

        public async Task<string?> CreateSharedLockAsync(CreateUpdateSharedLockDto createUpdateSharedLock)
        {
            ArgumentNullException.ThrowIfNull(createUpdateSharedLock, nameof(createUpdateSharedLock));

            var result = await PostObjectAsync("locks/shared-locks").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<CreateSharedLockRepDto>().ConfigureAwait(false);
            return output?.Id;
        }

        public async Task<SharedLockForPublic?> GetSharedLockAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"locks/shared-locks/{sharedLockId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<SharedLockForPublic>().ConfigureAwait(false);
        }

        public async Task UpdateSharedLockAsync(string sharedLockId, CreateUpdateSharedLockDto createUpdateSharedLock)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));
            ArgumentNullException.ThrowIfNull(createUpdateSharedLock, nameof(createUpdateSharedLock));

            var result = await PutObjectAsync($"locks/shared-locks/{sharedLockId}", obj: createUpdateSharedLock).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateSharedLockExtensionsAsync(string sharedLockId, EditLockExtensionsDto editLockExtensions)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));
            ArgumentNullException.ThrowIfNull(editLockExtensions);

            var result = await PutObjectAsync($"locks/shared-locks/{sharedLockId}/extensions", obj: editLockExtensions).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task ArchiveSharedLockAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await PostObjectAsync($"locks/shared-locks/{sharedLockId}/archive").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<bool?> GetSharedLockIsFavoriteAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"shared-locks/{sharedLockId}/favorite").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<IsFavoriteSharedLockRepDto>().ConfigureAwait(false);
            return output?.Favorite;
        }

        public async Task FavoriteSharedLockAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await PutObjectAsync($"shared-locks/{sharedLockId}/favorite").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task UnfavoriteSharedLockAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await DeleteAsync($"shared-locks/{sharedLockId}/favorite").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<FavoriteSharedLocksRepDto?> GetFavoriteSharedLocksAsync(FavoriteSharedLocksDto getFavoriteSharedLocks)
        {
            ArgumentNullException.ThrowIfNull(getFavoriteSharedLocks);

            var result = await PostObjectAsync("favorites/shared-locks").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<FavoriteSharedLocksRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Locks

        public async Task<LockForPublic[]?> GetLocksAsync(UserLockStatus? status = null)
        {
            Dictionary<string, string> parameters = [];

            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);

            var result = await GetAsync("locks", parameters).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LockForPublic[]>().ConfigureAwait(false);
        }

        public async Task<LockForPublic?> GetLockAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LockForPublic>().ConfigureAwait(false);
        }

        public async Task ArchiveLockAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await PostObjectAsync($"locks/{lockId}/archive").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task ArchiveKeyholderLockAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await PostObjectAsync($"locks/{lockId}/archive/keyholder").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task AddLockTimeAsync(string lockId, int timeToAdd)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            UpdateTimeDto dto = new() { Duration = timeToAdd };

            var result = await PostObjectAsync($"locks/{lockId}/update-time", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task SetLockFreezeAsync(string lockId, bool isFrozen)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            SetFreezeDto dto = new() { IsFrozen = isFrozen };

            var result = await PostObjectAsync($"locks/{lockId}/freeze", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task UnlockLockAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await PostObjectAsync($"locks/{lockId}/unlock").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task SetLockTimeInfoAsync(string lockId, bool? displayRemainingTime, bool? hideTimeLogs)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            SetLockSettingsDto dto = new() { DisplayRemainingTime = displayRemainingTime, HideTimeLogs = hideTimeLogs };

            var result = await PostObjectAsync($"locks/{lockId}/settings", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task SetLockMaxLimitDateAsync(string lockId, DateTimeOffset maxLimitDate, bool disableMaxLimitDate)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            IncreaseMaxLimitDateDto dto = new() { MaxLimitDate = maxLimitDate, DisableMaxLimitDate = disableMaxLimitDate };

            var result = await PostObjectAsync($"locks/{lockId}/max-limit-date", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task TrustLockKeyholderAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await PostObjectAsync($"locks/{lockId}/trust-keyholder").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<CombinationForPublic?> GetLockCombinationAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}/combination").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);
        }

        public async Task<HistoryRepDto?> GetLockHistoryAsync(string lockId, LockHistoryDto getLockHistory)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentNullException.ThrowIfNull(getLockHistory);

            var result = await PostObjectAsync($"locks/{lockId}/history", obj: getLockHistory).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<HistoryRepDto>().ConfigureAwait(false);
        }

        public async Task SetLockAsTestAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await PutObjectAsync($"locks/{lockId}/is-test-lock").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<LockInfoFromExtensionRepDto?> GetLockExtensionInfoAsync(string lockId, string extensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(extensionId, nameof(extensionId));

            var result = await GetAsync($"locks/{lockId}/extensions/{extensionId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LockInfoFromExtensionRepDto>().ConfigureAwait(false);
        }

        public async Task<ApiResult> TriggerLockActionAsync(string lockId, string extensionId, TriggerExtensionActionDto triggerExtensionAction)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(extensionId, nameof(extensionId));
            ArgumentNullException.ThrowIfNull(triggerExtensionAction);

            var result = await PostObjectAsync($"locks/{lockId}/extensions/{extensionId}/action", obj: triggerExtensionAction).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return result;
        }

        #endregion

        #region Lock Creation

        public async Task<string?> CreateLockAsync(CreateLockDto createLock)
        {
            ArgumentNullException.ThrowIfNull(createLock);

            var result = await PostObjectAsync("locks", obj: createLock).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<LockCreatedRepDto>().ConfigureAwait(false);
            return output?.LockId;
        }

        public async Task UpdateLockExtensionsAsync(string lockId, EditLockExtensionsDto editLockExtensions)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId)); 
            ArgumentNullException.ThrowIfNull(editLockExtensions);

            var result = await PostObjectAsync($"locks/{lockId}/extensions", obj: editLockExtensions).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<string?> CreateLockFromSharedLockAsync(string sharedLockId, CreateLockFromSharedLockDto createLockFromSharedLock)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId)); 
            ArgumentNullException.ThrowIfNull(createLockFromSharedLock);

            var result = await PostObjectAsync($"public-locks/{sharedLockId}/create-lock", obj: createLockFromSharedLock).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<LockCreatedRepDto>().ConfigureAwait(false);
            return output?.LockId;
        }

        #endregion

        #region Profile

        public async Task<LockForPublic[]?> GetUserLocksAsync(string userId)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"locks/user/{userId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LockForPublic[]>().ConfigureAwait(false);
        }

        public async Task<UserForPublic?> GetUserAsync(string userId)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"users/profile/by-id/{userId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);
        }

        public async Task<UserForPublic?> GetUserByNameAsync(string userName)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            var result = await GetAsync($"users/profile/{userName}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);
        }

        public async Task<ProfileRepDto?> GetUserDetailsAsync(string userName)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            var result = await GetAsync($"users/profile/{userName}/details").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ProfileRepDto>().ConfigureAwait(false);
        }

        public async Task<UserBadgeCount?> GetBadgeCountsAsync()
        {
            var result = await GetAsync("users/badge/count").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<UserBadgeCount>().ConfigureAwait(false);
        }

        public async Task<CurrentUserForProfileSettings?> GetUserProfileInfoAsync()
        {
            var result = await GetAsync("auth/profile/update").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CurrentUserForProfileSettings>().ConfigureAwait(false);
        }

        public async Task<CurrentUser?> GetUserInfoAsync()
        {
            var result = await GetAsync("auth/profile").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CurrentUser>().ConfigureAwait(false);
        }

        #endregion

        #region Combinations

        //TODO: Test this
        public async Task<string?> UploadCombinationImageAsync(UploadCombinationImageDto uploadCombinationImage)
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

            var result = await PostContentAsync("combinations/image", content: multipartContent).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<CreateCodeRepDto>().ConfigureAwait(false);
            return output?.CombinationId;
        }

        public async Task<string?> CreateCodeCombinationAsync(string code)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));

            CreateCodeDto dto = new() { Code = code };

            var result = await PostObjectAsync("combinations/code", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            var output = await result.GetObjectAsync<CreateCodeRepDto>().ConfigureAwait(false);
            return output?.CombinationId;
        }

        #endregion

        #region Extensions

        public async Task<ExtensionForPublic[]?> GetExtensionsAsync()
        {
            var result = await GetAsync("extensions").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ExtensionForPublic[]>().ConfigureAwait(false);
        }

        #endregion

        #region Session Offer

        public async Task CreateKeyholdingOfferAsync(string lockId, string keyholderUserName)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(keyholderUserName, nameof(keyholderUserName));

            CreateOfferRequestDto dto = new() { Keyholder = keyholderUserName };

            var result = await PostObjectAsync($"session-offer/lock/{lockId}", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task AcceptKeyholdingRequestAsync(string offerToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(offerToken, nameof(offerToken));

            var result = await GetAsync($"session-offer/token/{offerToken}/accept").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<SessionOfferRequestForPublic[]?> GetKeyholdingOffersAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"session-offer/lock/{lockId}/status").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<SessionOfferRequestForPublic[]>().ConfigureAwait(false);
        }

        public async Task<LockForPublic?> GetLockByKeyholdingOfferAsync(string offerToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(offerToken, nameof(offerToken));

            var result = await GetAsync($"session-offer/token/{offerToken}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LockForPublic>().ConfigureAwait(false);
        }

        public async Task RespondToKeyholdingOfferAsync(string sessionRequestId, bool accept)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionRequestId, nameof(sessionRequestId));

            ValidateOfferRequestDto dto = new() { Accept = accept };

            var result = await PostObjectAsync($"session-offer/{sessionRequestId}", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task ArchiveKeyholdingOfferAsync(string sessionRequestId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionRequestId, nameof(sessionRequestId));

            var result = await GetAsync($"session-offer/{sessionRequestId}/archive").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<SessionOfferRequestForKeyholder[]?> GetKeyholdingRequestsAsync()
        {
            var result = await GetAsync("session-offer/requests").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<SessionOfferRequestForKeyholder[]>().ConfigureAwait(false);
        }

        #endregion

        #region Messaging

        //NOTE: Limit has a range of 1-100, offset should be the value returned from a previous call
        public async Task<ConversationsRepDto?> GetConversationsAsync(int? limit = null, ConversationStatus? status = null, DateTimeOffset? offset = null)
        {
            Dictionary<string, string> parameters = [];

            if (limit is not null) parameters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));

            if (status is not null) parameters.Add("status", EnumStringConverter.GetMemberValueFromEnum(status)!);

            if (offset is not null) parameters.Add("offset", offset.ToString()!);

            var result = await GetAsync("conversations", parameters).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ConversationsRepDto>().ConfigureAwait(false);
        }

        public async Task<ConversationForPublic?> CreateConversationAsync(CreateConversationDto createConversation)
        {
            ArgumentNullException.ThrowIfNull(createConversation);

            var result = await PostObjectAsync("conversations", obj: createConversation).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);
        }

        public async Task<ConversationForPublic?> GetConversationByUserIdAsync(string userId)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));

            var result = await GetAsync($"conversations/by-user/{userId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);
        }

        public async Task<MessageForPublic?> AddMessageToConversationAsync(string conversationId, UpdateConversationDto updateConversation)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));
            ArgumentNullException.ThrowIfNull(updateConversation);

            var result = await PostObjectAsync($"conversations/{conversationId}", obj: updateConversation).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<MessageForPublic>().ConfigureAwait(false);
        }

        public async Task<ConversationForPublic?> GetConversationAsync(string conversationId)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            var result = await GetAsync($"conversations/{conversationId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ConversationForPublic>().ConfigureAwait(false);
        }

        public async Task SetConversationStatusAsync(string conversationId, SetConversationStatusDtoStatus status)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            SetConversationStatusDto dto = new() { Status = status };

            var result = await PutObjectAsync($"conversations/{conversationId}/status", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task SetConversationStatusAsync(string conversationId, bool unread)
        {
            ArgumentException.ThrowIfNullOrEmpty(conversationId, nameof(conversationId));

            SetConversationUnreadDto dto = new() { Unread = unread };

            var result = await PutObjectAsync($"conversations/{conversationId}/unread", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        //NOTE: Limit has a range of 1-100
        public async Task<MessagesRepDto?> GetConversationMessagesAsync(string conversationId, int? limit = null, string? lastId = null)
        {
            Dictionary<string, string> parameters = [];

            if (limit is not null) parameters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));

            if (lastId is not null) parameters.Add("lastId", lastId);

            var result = await GetAsync($"conversations/{conversationId}/messages", parameters).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<MessagesRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Extensions - Temporary Opening

        public async Task<CombinationForPublic?> GetTemporaryOpeningLockCombinationAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"extensions/temporary-opening/{lockId}/combination").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);
        }

        public async Task SetTemporaryOpeningCombinationAsync(string lockId, string combinationId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            TemporaryOpeningSetCombinationDto dto = new() { CombinationId = combinationId };

            var result = await PostObjectAsync($"extensions/temporary-opening/{lockId}/combination", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<CombinationForPublic?> GetTemporaryOpeningLockCombinationFromActionLogAsync(string lockId, string actionLogId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(actionLogId, nameof(actionLogId));

            var result = await GetAsync($"/extensions/temporary-opening/{lockId}/action-log/{actionLogId}/combination").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CombinationForPublic>().ConfigureAwait(false);
        }


        #endregion

        #region Community Events

        public async Task<CommunityEventCategory[]?> GetCommunityEventCategoriesAsync()
        {
            var result = await GetAsync("community-event/categories").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<CommunityEventCategory[]>().ConfigureAwait(false);
        }

        public async Task<PeriodDetailsRepDto?> GetCommunityEventTaskDetailsAsync(DateTimeOffset date)
        {
            PeriodDetailsDto dto = new() { Date = date };

            var result = await PostObjectAsync("community-event/details", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<PeriodDetailsRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Settings

        public async Task<AppSettingsDto?> GetAppSettingsAsync()
        {
            var result = await GetAsync("settings").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<AppSettingsDto>().ConfigureAwait(false);
        }

        #endregion

        #region Users

        public async Task<UserForPublic[]?> SearchUsersAsync(string userName)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            SearchUserUsernameDto dto = new() { Search = userName };

            var result = await PostObjectAsync("users/search/by-username", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<UserForPublic[]>().ConfigureAwait(false);
        }

        public async Task<UserForPublic?> GetUserByDiscordIdAsync(string discordId)
        {
            ArgumentException.ThrowIfNullOrEmpty(discordId, nameof(discordId));

            var result = await GetAsync($"users/search/by-discord-id/{discordId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<UserForPublic>().ConfigureAwait(false);
        }

        #endregion

        #region Keyholder

        public async Task<KeyholderSearchLocksRepDto?> SearchLockedUsersAsync(KeyholderSearchLocksDto keyholderSearchLocks)
        {
            ArgumentNullException.ThrowIfNull(keyholderSearchLocks);

            var result = await PostObjectAsync("keyholder/locks/search", obj: keyholderSearchLocks).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<KeyholderSearchLocksRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Public Locks

        public async Task<PublicLockForPublic?> GetPublicLockAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"public-locks/{sharedLockId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<PublicLockForPublic>().ConfigureAwait(false);
        }

        /// <summary>
        /// Return a PNG preview of a lock for sharing on social media
        /// </summary>
        public async Task<byte[]> GetLockImageAsync(string sharedLockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sharedLockId, nameof(sharedLockId));

            var result = await GetAsync($"public-locks/images/{sharedLockId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetBytesAsync().ConfigureAwait(false);
        }

        public async Task<SearchPublicLockRepDto?> SearchPublicLocksAsync(SearchPublicLockDto searchPublicLock)
        {
            ArgumentNullException.ThrowIfNull(searchPublicLock);

            var result = await PostObjectAsync("public-locks/search", obj: searchPublicLock).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<SearchPublicLockRepDto>().ConfigureAwait(false);
        }

        public async Task<ExploreCategoryForPublic[]?> GetPublicLocksFromExplorePageAsync()
        {
            var result = await GetAsync("/explore/categories").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<ExploreCategoryForPublic[]>().ConfigureAwait(false);
        }

        #endregion

        #region Extensions - Verification Picture

        //TODO: Test this, and check if contentType is allowed
        public async Task UploadVerificationPictureAsync(string lockId, byte[] data, string? contentType = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentNullException.ThrowIfNull(data);

            using ByteArrayContent byteContent = new(data);

            if (!string.IsNullOrEmpty(contentType)) byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

            var result = await PostContentAsync($"extensions/verification-picture/{lockId}/submit", content: byteContent).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();
        }

        public async Task<VerificationPictureHistoryEntry[]?> GetVerificationPicturesAsync(string lockId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));

            var result = await GetAsync($"locks/{lockId}/verification-pictures").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<VerificationPictureHistoryEntry[]>().ConfigureAwait(false);
        }

        #endregion

        #region Extensions - Share Links

        public async Task<LinkInfoActionRepDto?> GetShareLinkInfoFromSessionIdAsync(string sessionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(sessionId, nameof(sessionId));

            var result = await GetAsync($"shared-links/{sessionId}").ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<LinkInfoActionRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Extension Actions

        public async Task ResolveTaskAsync(string lockId, string tasksExtensionId, bool isCompleted)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "completeTask",
                Payload = JsonSerializer.SerializeToElement(new ResolveTaskActionModel { IsCompleted = isCompleted })
            };

            _ = await TriggerLockActionAsync(lockId, tasksExtensionId, dto).ConfigureAwait(false);
        }

        public async Task<int?> ShareLinkVoteAsync(string lockId, string linkExtensionId, string sessionId, ShareLinkVoteAction voteAction)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "vote",
                Payload = JsonSerializer.SerializeToElement(new ShareLinkeVoteActionModel { Action = voteAction, SessionId = sessionId})
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto).ConfigureAwait(false);

            var output = await result.GetObjectAsync<ShareLinkVoteActionRepDto>().ConfigureAwait(false);
            return output?.Duration;
        }

        public async Task<SpinWheelActionModel?> SpinWheelOfFortuneAsync(string lockId, string diceExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(diceExtensionId, nameof(diceExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, diceExtensionId, dto).ConfigureAwait(false);

            return await result.GetObjectAsync<SpinWheelActionModel>().ConfigureAwait(false);
        }

        public async Task<RollDiceActionModel?> RollDiceAsync(string lockId, string diceExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(diceExtensionId, nameof(diceExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, diceExtensionId, dto).ConfigureAwait(false);

            return await result.GetObjectAsync<RollDiceActionModel>().ConfigureAwait(false);
        }

        public async Task PilloryLockAsync(string lockId, string pilloryExtensionId, string? reason, int duration)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(pilloryExtensionId, nameof(pilloryExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new PilloryLockActionParamsModel { Reason = reason, Duration = duration })
            };

            _ = await TriggerLockActionAsync(lockId, pilloryExtensionId, dto).ConfigureAwait(false);
        }

        public async Task<PilloryVoteInfoActionRepDto[]?> GetPilloryVoteInfoAsync(string lockId, string pilloryExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(pilloryExtensionId, nameof(pilloryExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getStatus"
            };

            var result = await TriggerLockActionAsync(lockId, pilloryExtensionId, dto).ConfigureAwait(false);

            return await result.GetObjectAsync<PilloryVoteInfoActionRepDto[]>().ConfigureAwait(false);

        }

        public async Task UpdateLockTasksAsync(string lockId, string tasksExtensionId, List<TaskActionParamsModel> tasks)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "updateTasks",
                Payload = JsonSerializer.SerializeToElement(new UpdateTasksActionModel { Tasks = tasks })
            };

            _ = await TriggerLockActionAsync(lockId, tasksExtensionId, dto).ConfigureAwait(false);
        }

        public async Task AssignTaskAsync(string lockId, string tasksExtensionId, TaskActionParamsModel task)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "assignTask",
                Payload = JsonSerializer.SerializeToElement(new AssignTaskActionModel { Task = task })
            };

            _ = await TriggerLockActionAsync(lockId, tasksExtensionId, dto).ConfigureAwait(false);
        }

        public async Task AssignRandomTaskAsync(string lockId, string tasksExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new AssignVoteTaskActionModel())
            };

            _ = await TriggerLockActionAsync(lockId, tasksExtensionId, dto).ConfigureAwait(false);
        }

        public async Task AssignVoteTaskAsync(string lockId, string tasksExtensionId, int duration)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(tasksExtensionId, nameof(tasksExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit",
                Payload = JsonSerializer.SerializeToElement(new AssignVoteTaskActionModel { RequestVote = true, VoteDuration = duration })
            };

            _ = await TriggerLockActionAsync(lockId, tasksExtensionId, dto).ConfigureAwait(false);
        }

        public async Task<string?> GetShareLinkAsync(string lockId, string linkExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getLink"
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto).ConfigureAwait(false);

            var output = await result.GetObjectAsync<LinkActionRepDto>().ConfigureAwait(false);
            return output?.Link;
        }

        public async Task<LinkInfoActionRepDto?> GetShareLinkInfoAsync(string lockId, string linkExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(linkExtensionId, nameof(linkExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "getInfo"
            };

            var result = await TriggerLockActionAsync(lockId, linkExtensionId, dto).ConfigureAwait(false);

            return await result.GetObjectAsync<LinkInfoActionRepDto>().ConfigureAwait(false);
        }

        public async Task CreateVerificationPictureRequestAsync(string lockId, string verificationPictureExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(verificationPictureExtensionId, nameof(verificationPictureExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "createVerificationRequest"
            };

            _ = await TriggerLockActionAsync(lockId, verificationPictureExtensionId, dto).ConfigureAwait(false);
        }

        public async Task KeyholderTemporarilyUnlockAsync(string lockId, string temporaryOpeningExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(temporaryOpeningExtensionId, nameof(temporaryOpeningExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "keyholderOpen"
            };

            _ = await TriggerLockActionAsync(lockId, temporaryOpeningExtensionId, dto).ConfigureAwait(false);
        }

        public async Task WearerTemporarilyUnlockAsync(string lockId, string temporaryOpeningExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(temporaryOpeningExtensionId, nameof(temporaryOpeningExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            _ = await TriggerLockActionAsync(lockId, temporaryOpeningExtensionId, dto).ConfigureAwait(false);
        }

        public async Task<GuessTheTimerActionRepDto?> SubmitGuessToGuessTheTimerAsync(string lockId, string guessTheTimerExtensionId)
        {
            ArgumentException.ThrowIfNullOrEmpty(lockId, nameof(lockId));
            ArgumentException.ThrowIfNullOrEmpty(guessTheTimerExtensionId, nameof(guessTheTimerExtensionId));

            TriggerExtensionActionDto dto = new()
            {
                Action = "submit"
            };

            var result = await TriggerLockActionAsync(lockId, guessTheTimerExtensionId, dto).ConfigureAwait(false);

            return await result.GetObjectAsync<GuessTheTimerActionRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Activity

        public async Task<PostsRepDto?> GetPublicActivityAsync()
        {
            //NOTE: The API ignores the GetPostsDto, but we'll leave this here just in case.
            PostsDto dto = new() { Limit = 10 };

            var result = await PostObjectAsync("posts", obj: dto).ConfigureAwait(false);
            _ = result.HttpResponse.EnsureSuccessStatusCode();

            return await result.GetObjectAsync<PostsRepDto>().ConfigureAwait(false);
        }

        #endregion

        #region Http Handling

        private async Task<ApiResult> GetAsync(string relativeUri, Dictionary<string, string>? parameters = null)
        {
            return new ApiResult(await _httpClient.GetAsync(BuildUrl(relativeUri, parameters)).ConfigureAwait(false));
        }

        private async Task<ApiResult> PostObjectAsync(string relativeUri, Dictionary<string, string>? parameters = null, object? obj = null)
        {
            using var content = obj is null ? null : new StringContent(JsonSerializer.Serialize(obj), MediaTypeHeaderValue.Parse("application/json"));
            return new ApiResult(await _httpClient.PostAsync(BuildUrl(relativeUri, parameters), content).ConfigureAwait(false));
        }

        private async Task<ApiResult> PostContentAsync(string relativeUri, Dictionary<string, string>? parameters = null, HttpContent? content = null)
        {
            return new ApiResult(await _httpClient.PostAsync(BuildUrl(relativeUri, parameters), content).ConfigureAwait(false));
        }

        private async Task<ApiResult> PutObjectAsync(string relativeUri, Dictionary<string, string>? parameters = null, object? obj = null)
        {
            using var content = obj is null ? null : new StringContent(JsonSerializer.Serialize(obj), MediaTypeHeaderValue.Parse("application/json"));
            return new ApiResult(await _httpClient.PutAsync(BuildUrl(relativeUri, parameters), content).ConfigureAwait(false));
        }

        private async Task<ApiResult> DeleteAsync(string relativeUri, Dictionary<string, string>? parameters = null)
        {
            return new ApiResult(await _httpClient.DeleteAsync(BuildUrl(relativeUri, parameters)).ConfigureAwait(false));
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

        #endregion

    }
}