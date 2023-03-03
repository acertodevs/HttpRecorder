using System;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using Xunit;

namespace HttpRecorder.Tests.Extensions
{
    public class HttpContentExtensionsTests
    {
        [Theory]
        [InlineData("image/png")]
        [InlineData("audio/mp3")]
        [InlineData("video/mp4")]
        [InlineData("application/pdf")]
        [InlineData("multipart/form-data")]
        public void ItShouldDetectBinaryMimeTypes(string mimeType)
        {
            var content = new ByteArrayContent(Array.Empty<byte>());
            content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

            bool result = content.IsBinary();

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("application/javascript")]
        [InlineData("application/json")]
        [InlineData("application/typescript")]
        [InlineData("application/xhtml+xml")]
        [InlineData("application/xml")]
        public void ItSholdIgnoreTextApplicationTypes(string mimeType)
        {
            var content = new ByteArrayContent(Array.Empty<byte>());
            content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

            bool result = content.IsBinary();

            result.Should().BeFalse();
        }
    }
}
