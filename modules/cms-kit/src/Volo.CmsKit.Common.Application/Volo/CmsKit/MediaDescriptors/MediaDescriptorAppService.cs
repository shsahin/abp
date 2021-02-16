﻿using System;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;

namespace Volo.CmsKit.MediaDescriptors
{
    [RequiresGlobalFeature(typeof(MediaFeature))]
    public class MediaDescriptorAppService : CmsKitAppServiceBase, IMediaDescriptorAppService
    {
        protected readonly IMediaDescriptorRepository MediaDescriptorRepository;
        protected readonly IBlobContainer<MediaContainer> MediaContainer;

        public MediaDescriptorAppService(IMediaDescriptorRepository mediaDescriptorRepository, IBlobContainer<MediaContainer> mediaContainer)
        {
            MediaDescriptorRepository = mediaDescriptorRepository;
            MediaContainer = mediaContainer;
        }

        public virtual async Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            var entity = await MediaDescriptorRepository.GetAsync(id);
            var stream = await MediaContainer.GetAsync(id.ToString());

            return new RemoteStreamContent(stream)
            {
                ContentType = entity.MimeType
            };
        }
    }
}