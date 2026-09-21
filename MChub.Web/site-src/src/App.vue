<script setup>
import SiteHeader from './components/SiteHeader.vue'
import HeroSection from './components/HeroSection.vue'
import FeaturesSection from './components/FeaturesSection.vue'
import DownloadSection from './components/DownloadSection.vue'
import OpenSourceSection from './components/OpenSourceSection.vue'
import FooterView from './components/FooterView.vue'
</script>

<template>
  <SiteHeader />
  <main>
    <HeroSection />
    <FeaturesSection />
    <DownloadSection />
    <OpenSourceSection />
  </main>
  <FooterView />
</template>
